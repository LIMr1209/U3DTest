using UnityEngine;
using UnityEngine.Rendering;

// 自定义渲染管道 https://zhuanlan.zhihu.com/p/430789702

public class SRenderPipeline : RenderPipeline
{
    CameraRenderer renderer = new CameraRenderer();

    protected override void Render(ScriptableRenderContext context, Camera[] cameras)

    {
        foreach (var cam in cameras)
        {
            renderer.Render(context, cam);
        }
    }
}


public partial class CameraRenderer
{
    public ScriptableRenderContext context;
    public Camera camera;
    const string bufferName = "Custom Render Camera"; // Frame Debug中识别
    CommandBuffer commandBuffer = new CommandBuffer {name = bufferName};

    CullingResults cullRes; // 记录更加详细的Cull信息

    // 比如需要指定哪一种着色器通道作为默认渲染通道，这里我们指定SRPDefaultUnlit通道
    // 管线只会对指定Unlit着色器相关的物体进行渲染
    static ShaderTagId unlitShaderTagId = new ShaderTagId("SRPDefaultUnlit");

    // 为了能够渲染所有物体，并且兼容旧版本的所有着色器，我们需要定义新的ShaderTagId：

    public void Render(ScriptableRenderContext c, Camera cam)
    {
        context = c;
        camera = cam;
        if (!Cull())
        {
            return;
        }

        Setup();
        DrawVisibleGeometry();
        DrawUnSupportShader();
        DrawGizmos();
        Submit();
    }

    void Setup()
    {
        context.SetupCameraProperties(camera); // 此函数设置视图、投影和剪切平面全局着色器矩阵变量
        // 前两个参数表示是否应该清除深度和颜色数据  清除的颜色 清除 帧缓冲对象
        commandBuffer.ClearRenderTarget(true, true, Color.clear);
        commandBuffer.BeginSample(bufferName);
        ExecuteCommand();
    }

    void ExecuteCommand()
    {
        // 命令缓冲区中复制命令，但不会对它清除，如果我们想要重用它，我们必须显式地进行Clear操作
        context.ExecuteCommandBuffer(commandBuffer); // 自定义图形命令缓冲区的执行
        commandBuffer.Clear(); // 清楚命令
    }

    // 为了正确排序透明物体与不透明物体，所以需要重新编写不同的排序规则，
    // 并且发现绘制的最后结果只出现了天空盒与非透明物体，而透明物体却没有绘制到屏幕上。
    // 出现这个问题的原因是因为透明物体没有写入深度，导致后绘制的物体会覆盖之前绘制的物体。
    // 解决方法是先绘制不透明物体，然后是天空盒，最后是透明的物体
    void DrawVisibleGeometry()
    {
        // 绘制的排序规则，比如是Orthographic还是Distance-based的排序方式
        var sortingSettings = new SortingSettings(camera)
        {
            // 不透明对象的典型排序(从前到后)
            criteria = SortingCriteria.CommonOpaque
        };
        // 绘图设置
        var drawSettings = new DrawingSettings(unlitShaderTagId, sortingSettings);
        // 过滤设置,先绘制不透明物体
        var filteringSettings = new FilteringSettings(RenderQueueRange.opaque);
        context.DrawRenderers(cullRes, ref drawSettings, ref filteringSettings);
        context.DrawSkybox(camera); // 再绘制天空盒
        // 最后绘制透明物体，排序规则改为透明排序
        sortingSettings.criteria = SortingCriteria.CommonTransparent;
        drawSettings.sortingSettings = sortingSettings;
        // 绘制透明队列
        filteringSettings.renderQueueRange = RenderQueueRange.transparent;
        context.DrawRenderers(
            cullRes, ref drawSettings, ref filteringSettings
        );
    }

    void Submit()
    {
        commandBuffer.EndSample(bufferName);
        ExecuteCommand();
        context.Submit(); // 命令提交
    }

    bool Cull()
    {
        // 要想确定哪些物体需要被剔除
        ScriptableCullingParameters p;
        // 也可以 if (camera.TryGetCullingParameters(out ScriptableCullingParameters p))
        // 在相机对象上调用TryGetCullingParameters。它返回ScriptableCullingParameters对象参数是否能够成功检索的布尔值数据
        if (camera.TryGetCullingParameters(out p))
        {
            cullRes = context.Cull(ref p);
            return true;
        }

        return false;
    }
}