using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestOtherGUI : MonoBehaviour
    {
        public Rect area = new Rect(1, 1, 100, 20);
        // public float scrollLength = 1.0f; 
        // private string text = "This is a textField";
        // private bool toggle = false;
        // private int toolbar = 1;
        // private float slider = 3.0f;
        // Vector2 scrollPosition = Vector2.zero;
        // private Rect scrollArea = new Rect(0, 0, 220, 200);

        private void OnGUI()
        {
            // toggle = GUI.Toggle(area, toggle, "This is toggle"); // 选中
            // toolbar = GUI.Toolbar(area, toolbar, new string[] {"toolbar_1", "toolbar_2", "toolbar_3"}); // 选中工具栏 返回索引
            // toolbar = GUI.SelectionGrid(area, toolbar, new string[] {"Selection_1", "Selection_2", "Selection_3", "Selection_4"}, 3); // xCount 一行最多显示几个
            // slider = GUI.HorizontalSlider(area, slider, 0.0f, 10.0f); // 横向坐标轴
            // slider = GUI.VerticalSlider(area, slider, 0.0f, 10.0f); // 纵向坐标轴
            // 滚动条 scrollLength 滚动条大小 
            // slider = GUI.VerticalScrollbar(area, slider, scrollLength, 0.0f, 10.0f); // 纵向
            // slider = GUI.HorizontalScrollbar(area, slider, scrollLength, 0.0f, 10.0f); // 横向
            
            
            // 滚动条 区域 超过区域自动使用滚动条
            // scrollPosition = GUI.BeginScrollView(area, scrollPosition, scrollArea);
            // GUI.Button(new Rect(0, 0, 100, 20), "top-left");
            // GUI.Button(new Rect(120, 0, 100, 20), "top-right");
            // GUI.Button(new Rect(0, 180, 100, 20), "bottom-left");
            // GUI.Button(new Rect(120, 180, 100, 20), "bottom-right");
            // GUI.EndScrollView();

            area = GUI.Window(0, area, windfunc, "My Window");
        }

        void windfunc(int windowId)
        {
            GUI.Button(new Rect(60, 50, 100, 20), "window button");
            GUI.DragWindow();
        }
    }
}