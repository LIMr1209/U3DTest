using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace DefaultNamespace
{
    public class RenderPipelineManagerTest : MonoBehaviour
    {
        private void Start()
        {
            RenderPipelineManager.activeRenderPipelineTypeChanged += ActiveRenderPipelineTypeChanged;
            RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;
            RenderPipelineManager.endCameraRendering += OnEndCameraRendering;
            RenderPipelineManager.beginContextRendering += OnBeginContextRendering;
            RenderPipelineManager.endContextRendering += OnEndContextRendering;
            RenderPipelineManager.beginFrameRendering += OnBeginFrameRendering;
            RenderPipelineManager.endFrameRendering += OnEndFrameRendering;
        }

        // 当 Unity 更改活动渲染管道并且新的 RenderPipeline 具有与旧的不同类型时
        private void ActiveRenderPipelineTypeChanged()
        {
            Debug.Log("ActiveRenderPipelineTypeChanged");
        }

        void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
        {
            //如果您正在使用URP或HDRP，Unity会自动调用此方法
            //如果要编写自定义SRP，则必须调用RenderPipeline.BeginCameraRendering
            Debug.Log("beginCameraRendering");
        }
        
        void OnEndCameraRendering(ScriptableRenderContext context, Camera camera)
        {
            //如果您正在使用URP或HDRP，Unity会自动调用此方法
            //如果要编写自定义SRP，则必须调用RenderPipeline.BeginCameraRendering
            Debug.Log("endFrameRendering");
        }
        
        void OnBeginContextRendering(ScriptableRenderContext context, List<Camera> cameras)
        {
            //如果您正在使用URP或HDRP，Unity会自动调用此方法
            //如果要编写自定义SRP，则必须调用RenderPipeline.BeginCameraRendering
            Debug.Log("beginContextRendering");
        }
        
        void OnEndContextRendering(ScriptableRenderContext context, List<Camera> cameras)
        {
            //如果您正在使用URP或HDRP，Unity会自动调用此方法
            //如果要编写自定义SRP，则必须调用RenderPipeline.BeginCameraRendering
            Debug.Log("endContextRendering");
        }
        
        void OnBeginFrameRendering(ScriptableRenderContext context, Camera[] cameras)
        {
            //如果您正在使用URP或HDRP，Unity会自动调用此方法
            //如果要编写自定义SRP，则必须调用RenderPipeline.BeginCameraRendering
            Debug.Log("endFrameRendering");
        }
        
        void OnEndFrameRendering(ScriptableRenderContext context, Camera[] cameras)
        {
            //如果您正在使用URP或HDRP，Unity会自动调用此方法
            //如果要编写自定义SRP，则必须调用RenderPipeline.BeginCameraRendering
            Debug.Log("beginFrameRendering");
        }

        void OnDestroy()
        {
            RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;
            RenderPipelineManager.endCameraRendering -= OnEndCameraRendering;
            RenderPipelineManager.beginContextRendering -= OnBeginContextRendering;
            RenderPipelineManager.endContextRendering -= OnEndContextRendering;
            RenderPipelineManager.beginFrameRendering -= OnBeginFrameRendering;
            RenderPipelineManager.endFrameRendering -= OnEndFrameRendering;
            
        }
    }
}