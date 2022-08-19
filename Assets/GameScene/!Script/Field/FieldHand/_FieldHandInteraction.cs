using UnityEngine;
using UnityEngine.EventSystems;

namespace _cov._FieldHand
{
    public class _FieldHandInteraction : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData?.pointerDrag == null)
            {
                return;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData?.pointerDrag == null)
            {
                return;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData?.pointerDrag == null)
            {
                return;
            }
        }
    }
}
