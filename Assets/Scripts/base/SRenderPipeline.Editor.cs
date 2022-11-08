using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;


public partial class CameraRenderer
{
    partial void DrawUnSupportShader(); // 定义声明
    partial void DrawGizmos();
#if UNITY_EDITOR
    // 为了能够渲染所有物体，并且兼容旧版本的所有着色器，我们需要定义新的ShaderTagId：
    private static ShaderTagId[] legacyShaderTagIds =
    {
        new ShaderTagId("Always"),
        new ShaderTagId("ForwardBase"),
        new ShaderTagId("PrepassBase"),
        new ShaderTagId("Vertex"),
        new ShaderTagId("VertexLMRGBM"),
        new ShaderTagId("VertexLM")
    };

    static Material errorMaterial;

    partial void DrawUnSupportShader()
    {
        if (errorMaterial == null)
        {
            errorMaterial =
                new Material(Shader.Find("Hidden/InternalErrorShader"));
        }

        // 有时候自定义管线可能没法兼顾所有的着色器，如果出现不支持的着色器应该告诉用户，
        // 对应的着色器是不支持的，这可以使用 Hidden/InternalErrorShader 来设定。
        var drawingSettings = new DrawingSettings(
            legacyShaderTagIds[0], new SortingSettings(camera))
        {
            overrideMaterial = errorMaterial
        };
        // 可以通过在绘图设置上调用SetShaderPassName来绘制多个通道，并使用绘制顺序索引和标签作为参数
        // 新版本Unity，这里默认只有ForwardBase会起作用
        for (int i = 1; i < legacyShaderTagIds.Length; i++)
        {
            drawingSettings.SetShaderPassName(i, legacyShaderTagIds[i]);
        }

        var filteringSettings = FilteringSettings.defaultValue;
        context.DrawRenderers(
            cullRes, ref drawingSettings, ref filteringSettings);
    }

    partial void DrawGizmos()
    {
        // UnityEditor.Handles.ShouldRenderGizmos来检查gizmos是否应该被绘制
        if (Handles.ShouldRenderGizmos())
        {
            context.DrawGizmos(camera, GizmoSubset.PreImageEffects);
            context.DrawGizmos(camera, GizmoSubset.PostImageEffects);
        }
    }
#endif
}