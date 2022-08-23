//----------------------------------------------
//            MeshBaker
// Copyright © 2011-2012 Ian Deane
//----------------------------------------------
using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using DigitalOpus.MB.Core;

using UnityEditor;

namespace DigitalOpus.MB.Core{
	
    public class MB_MeshBakerSettingsEditor
    {
        private static GUIContent
            gc_renderTypeGUIContent = new GUIContent("Renderer", "The type of renderer to add to the combined mesh."),
            gc_lightmappingOptionGUIContent = new GUIContent("Lightmapping UVs", "preserve current lightmapping: Use this if all source objects are lightmapped and you want to preserve it. All source objects must use the same lightmap. DOES NOT WORK IN UNITY 5.\n\n" +
                                                                             "generate new UV Layout: Use this if you want to bake a lightmap after the combined mesh has been generated\n\n" +
                                                                             "copy UV2 unchanged: Use this if UV2 is being used for something other than lightmaping.\n\n" +
                                                                             "ignore UV2: A UV2 channel will not be generated for the combined mesh\n\n" +
                                                                             "copy UV2 unchanged to separate rects: Use this if your meshes include a custom lightmap that you want to use with the combined mesh.\n\n"),
            gc_clearBuffersAfterBakeGUIContent = new GUIContent("Clear Buffers After Bake", "Frees memory used by the MeshCombiner. Set to false if you want to update the combined mesh at runtime."),
            gc_doNormGUIContent = new GUIContent("Include Normals"),
            gc_doTanGUIContent = new GUIContent("Include Tangents"),
            gc_doColGUIContent = new GUIContent("Include Colors"),
            gc_doBlendShapeGUIContent = new GUIContent("Include Blend Shapes"),
            gc_doUVGUIContent = new GUIContent("Include UV"),
            gc_doUV3GUIContent = new GUIContent("Include UV3"),
            gc_doUV4GUIContent = new GUIContent("Include UV4"),
            gc_uv2HardAngleGUIContent = new GUIContent("  UV2 Hard Angle", "Angles greater than 'hard angle' in degrees will be split."),
            gc_uv2PackingMarginUV3GUIContent = new GUIContent("  UV2 Packing Margin", "The margin between islands in the UV layout measured in UV coordinates (0..1) not pixels"),
            gc_CenterMeshToBoundsCenter = new GUIContent("Center Mesh To Render Bounds", "Centers the verticies of the mesh about the render bounds center and translates the game object. This makes the combined meshes easier to work with. There is a performance and memory allocation cost to this so if you are frequently baking meshes at runtime disable it."),
            gc_OptimizeAfterBake = new GUIContent("Optimize After Bake", "This does the same thing that 'Optimize' does on the ModelImporter.");

        private SerializedProperty doNorm, doTan, doUV, doUV3, doUV4, doCol, doBlendShapes, lightmappingOption, renderType, clearBuffersAfterBake, uv2OutputParamsPackingMargin, uv2OutputParamsHardAngle, centerMeshToBoundsCenter, optimizeAfterBake;
        private MB_EditorStyles editorStyles = new MB_EditorStyles();

        /// <summary>
        /// This is the regular init method that should usually be used
        /// </summary>
        /// <param name="meshBakerSettingsData">Should be the MB_IMeshBakerSettingsData implementor</param>
        public void OnEnable(SerializedProperty meshBakerSettingsData)
        {
            _InitCommon(meshBakerSettingsData);
            clearBuffersAfterBake = meshBakerSettingsData.FindPropertyRelative("_clearBuffersAfterBake");
        }

        /// <summary>
        /// This is necessary for backward compatibility. MeshCombinerCommon does not contain the 
        /// clearBuffersAfterBake field. It is stored in the MeshBaker and is serialized in many, many
        /// scenes. This Init method is only used for MeshCombinerCommon.
        /// </summary>
        /// <param name="combiner"></param>
        /// <param name="meshBaker"></param>
        public void OnEnable(SerializedProperty combiner, SerializedObject meshBaker)
        {
            _InitCommon(combiner);
            clearBuffersAfterBake = meshBaker.FindProperty("clearBuffersAfterBake");
        }

        public void OnDisable()
        {
            editorStyles.DestroyTextures();
        }

        private void _InitCommon(SerializedProperty combiner)
        {
            renderType = combiner.FindPropertyRelative("_renderType");
            lightmappingOption = combiner.FindPropertyRelative("_lightmapOption");
            doNorm = combiner.FindPropertyRelative("_doNorm");
            doTan = combiner.FindPropertyRelative("_doTan");
            doUV = combiner.FindPropertyRelative("_doUV");
            doUV3 = combiner.FindPropertyRelative("_doUV3");
            doUV4 = combiner.FindPropertyRelative("_doUV4");
            doCol = combiner.FindPropertyRelative("_doCol");
            doBlendShapes = combiner.FindPropertyRelative("_doBlendShapes");
            uv2OutputParamsPackingMargin = combiner.FindPropertyRelative("_uv2UnwrappingParamsPackMargin");
            uv2OutputParamsHardAngle = combiner.FindPropertyRelative("_uv2UnwrappingParamsHardAngle");
            centerMeshToBoundsCenter = combiner.FindPropertyRelative("_recenterVertsToBoundsCenter");
            optimizeAfterBake = combiner.FindPropertyRelative("_optimizeAfterBake");
            editorStyles.Init();
        }

        public void DrawGUI(MB_IMeshBakerSettings momm, bool settingsEnabled)
        {
            EditorGUILayout.BeginVertical(editorStyles.editorBoxBackgroundStyle);
            GUI.enabled = settingsEnabled;
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(doNorm, gc_doNormGUIContent);
            EditorGUILayout.PropertyField(doTan, gc_doTanGUIContent);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(doUV, gc_doUVGUIContent);
            EditorGUILayout.PropertyField(doUV3, gc_doUV3GUIContent);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(doUV4, gc_doUV4GUIContent);
            EditorGUILayout.PropertyField(doCol, gc_doColGUIContent);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.PropertyField(doBlendShapes, gc_doBlendShapeGUIContent);

            if (momm.lightmapOption == MB2_LightmapOptions.preserve_current_lightmapping)
            {
                if (MBVersion.GetMajorVersion() == 5)
                {
                    EditorGUILayout.HelpBox("The best choice for Unity 5 is to Ignore_UV2 or Generate_New_UV2 layout. Unity's baked GI will create the UV2 layout it wants. See manual for more information.", MessageType.Warning);
                }
            }

            if (momm.lightmapOption == MB2_LightmapOptions.generate_new_UV2_layout)
            {
                EditorGUILayout.HelpBox("Generating new lightmap UVs can split vertices which can push the number of vertices over the 64k limit.", MessageType.Warning);
            }

            EditorGUILayout.PropertyField(lightmappingOption, gc_lightmappingOptionGUIContent);
            if (momm.lightmapOption == MB2_LightmapOptions.generate_new_UV2_layout)
            {
                EditorGUILayout.PropertyField(uv2OutputParamsHardAngle, gc_uv2HardAngleGUIContent);
                EditorGUILayout.PropertyField(uv2OutputParamsPackingMargin, gc_uv2PackingMarginUV3GUIContent);
                EditorGUILayout.Separator();
            }

            EditorGUILayout.PropertyField(renderType, gc_renderTypeGUIContent);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(clearBuffersAfterBake, gc_clearBuffersAfterBakeGUIContent);
            EditorGUILayout.PropertyField(centerMeshToBoundsCenter, gc_CenterMeshToBoundsCenter);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.PropertyField(optimizeAfterBake, gc_OptimizeAfterBake);
            GUI.enabled = true;
            EditorGUILayout.EndVertical();
        }
    }
}
