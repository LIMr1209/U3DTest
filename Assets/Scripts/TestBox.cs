using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestBox : MonoBehaviour
    {
        public Rect area;
        public Texture tex;
        public GUIContent myContent;
        public GUIStyle myStyle;
        private void OnGUI()
        {
            // GUI.Box(area, "this is a Bo!");
            // GUI.Box(area, tex);
            GUI.Box(area, myContent, myStyle);
            GUI.Box(new Rect(200,200,100,100), GUI.tooltip); // 选中提示
        }

    }
}