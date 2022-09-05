using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestLable : MonoBehaviour
    {
        public Rect area;
        public Texture tex;
        public GUIContent myContent;
        public GUIStyle myStyle;
        private void OnGUI()
        {
            // GUI.Label(area, "this is a label!");
            // GUI.Label(area, tex);
            GUI.Label(area, myContent, myStyle);
            GUI.Label(new Rect(200,200,100,100), GUI.tooltip); // 选中提示
        }

    }
}