using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestLayout : MonoBehaviour
    {
        public string text1 = "Button 1";
        public string text2 = "Button 2";
        public string text3 = "Button 3";
        public string text4 = "Button 4";

        public float width = 200f;
        public float maxWidth = 200f;
        public float minWidth = 200f;
        public bool expand = false;

        public Rect area = new Rect(20, 20, 200, 200);

        private void OnGUI()
        {
            // GUILayout.Label("label test1");
            // GUILayout.Button("label test2");
            // GUILayout.TextArea("label test3");
            // GUILayout.TextField("label test4");
            // GUILayout.BeginArea(area);// 指定区域自适应
            // GUILayout.Button(text1, GUILayout.Width(width));
            // GUILayout.Button(text2, GUILayout.MaxWidth(maxWidth));
            // GUILayout.Button(text3, GUILayout.MinWidth(minWidth));
            // GUILayout.Button(text4, GUILayout.ExpandWidth(expand));
            // GUILayout.EndArea();
            
            GUILayout.BeginArea(area);
            GUILayout.BeginHorizontal(); // 水平布局
            // region Vertical_A
            GUILayout.BeginVertical(); // 垂直布局
            GUILayout.Box("test_1");
            // GUILayout.Space(20); // 空闲 20像素
            GUILayout.FlexibleSpace(); // 空闲 自适应
            GUILayout.Box("test_2");
            GUILayout.FlexibleSpace();
            GUILayout.Box("test_5");
            GUILayout.EndVertical();
            GUILayout.BeginVertical(); // 垂直布局
            GUILayout.Box("test_3");
            GUILayout.Box("test_4");
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }
        
    }
}