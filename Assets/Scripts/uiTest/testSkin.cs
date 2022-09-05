using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class testSkin : MonoBehaviour
    {
        public GUISkin myGGUISkin;
        public GUIStyle myGUIStyle;
        private Rect windowRect;

        private void Start()
        {
            windowRect = new Rect(0, 0, 350, 510);
        }

        private void OnGUI()
        {
            GUI.skin = myGGUISkin;
            windowRect = GUI.Window(0, windowRect, myWindow, "aa");
        }

        void myWindow(int myWindowID)
        {
            GUILayout.BeginVertical();
            GUILayout.Space(8);
            GUILayout.Button("button", "Button"); // 利用反射 寻找guiskin 中得 testButton 样式
            GUILayout.Space(8);
            GUILayout.Label("label", "Button");
            GUILayout.EndVertical();
            GUI.DragWindow();
        }
    }
}