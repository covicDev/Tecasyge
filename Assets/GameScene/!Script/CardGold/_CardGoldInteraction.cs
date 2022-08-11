using UnityEngine;
using UnityEngine.EventSystems;

namespace _cov._CardGold
{
    public class _CardGoldInteraction : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public _ICardGoldController _CardGoldController => this.transform.GetComponent<_CardGoldController>();

        public void OnDrop(PointerEventData eventData)
        {
            
        }

        #region --- Mouse over action ---
        public void OnPointerEnter(PointerEventData eventData)
        {
            this._CardGoldController._Base._CardGoldBackgroundModerator._ShowCardGoldShadow();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            this._CardGoldController._Base._CardGoldBackgroundModerator._HideCardGoldShadow();
        }

        #endregion
    }
}
