using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class TestText : MonoBehaviour
    {
        public string text;
        public string lineText = "abcd\n abcd";
        public string password = "";
        private void OnGUI()
        {
            text = GUI.TextField(new Rect(0, 0, 100, 50), text);
            lineText = GUI.TextArea(new Rect(0, 50, 100, 50), lineText);
            password = GUI.PasswordField(new Rect(0, 150, 100, 50), password, '#');
        }
    }
}