using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestButton : MonoBehaviour
    {
        private int countButton = 0;
        private int countRepeatButton = 0;
        private void OnGUI()
        {
            bool btn = GUI.Button(new Rect(0, 0, 100, 20), "Button");
            bool rBtn = GUI.RepeatButton(new Rect(0, 50, 100, 20), "RepeatButton"); //按住button 反复调用
            if (btn)
            {
                countButton++;
            }

            if (rBtn)
            {
                countRepeatButton++;
            }
            GUI.Label(new Rect(200,0,200,20), "countButton："+countButton);
            GUI.Label(new Rect(200,50,200,20), "countRepeatButton："+countRepeatButton);
        }
    }
}