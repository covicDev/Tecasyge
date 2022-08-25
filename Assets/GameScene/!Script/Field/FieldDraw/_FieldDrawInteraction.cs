using UnityEngine;
using UnityEngine.EventSystems;

namespace _cov._FieldDraw
{
    public class _FieldDrawInteraction : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public _IFieldDrawController _FieldDrawController => this.transform.GetComponent<_FieldDrawController>();

        public void OnPointerClick(PointerEventData eventData)
        {
            this._FieldDrawController._Base._FieldDrawBackgroundModerator._SetBackgroundOfFieldDrawToOriginal();
            this._FieldDrawController._GetNextCard();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Cursor.visible = true;
            this._FieldDrawController._Base._FieldDrawBackgroundModerator._SetBackgroundOfFieldDrawToOriginal();
            this._FieldDrawController._Base._FieldDrawBackgroundModerator._ShowFieldDrawShadow();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            this._FieldDrawController._Base._FieldDrawBackgroundModerator._SetBackgroundOfFieldDrawToOriginal();
            this._FieldDrawController._Base._FieldDrawBackgroundModerator._HideFieldDrawShadow();
        }
    }
}