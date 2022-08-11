// 拖动事件 EventSystems
 
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class TestDragHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler, IInitializePotentialDragHandler
    
    {
        // 开始拖动
        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("OnBeginDrag "+gameObject.name);
        }

        // 结束拖动
        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("OnEndDrag "+gameObject.name);
        }

        // 物体A拖到物体B 
        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("OnDrop "+"From "+eventData.pointerDrag.name + "To "+ gameObject.name);
        }

        // 拖动中
        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("OnDrag "+gameObject.name);
        }

        // 拖动不超过阈值
        public void OnInitializePotentialDrag(PointerEventData eventData)
        {
            Debug.Log("OnInitializePotentialDrag "+gameObject.name);
        }
    }
}