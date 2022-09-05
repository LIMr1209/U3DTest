// 点击事件 EventSystems

using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class TestPointHandler : MonoBehaviour, IPointerClickHandler,IPointerDownHandler,IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        // 点击一次
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("OnPointerClick");
        }

        // 点下
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("OnPointerDown");
        }

        // 松开
        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("OnPointerUp");
        }

        // 进入
        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("OnPointerEnter");
        }

        // 离开
        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("OnPointerExit");
        }
    }
}