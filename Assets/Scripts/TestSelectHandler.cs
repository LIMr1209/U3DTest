// 选择事件 EventSystems

using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    public class TestSelectHandler : MonoBehaviour, ISelectHandler, IDeselectHandler, IUpdateSelectedHandler, IPointerDownHandler
    {
        // 选中
        public void OnSelect(BaseEventData eventData)
        {
            Debug.Log("OnSelect "+gameObject.name);
        }
        //取消选中
        public void OnDeselect(BaseEventData eventData)
        {
            Debug.Log("OnDeselect "+gameObject.name);
        }
        // 选中后
        public void OnUpdateSelected(BaseEventData eventData)
        {
            Debug.Log("OnUpdateSelected "+gameObject.name);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            // 点击选中
            EventSystem.current.SetSelectedGameObject(gameObject);
        }
    }
}