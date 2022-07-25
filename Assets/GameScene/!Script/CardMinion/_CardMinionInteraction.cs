using UnityEngine;
using UnityEngine.EventSystems;

namespace _cov._CardMinion
{
    [RequireComponent(typeof(_CardMinionController))]
    public class _CardMinionInteraction : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public _ICardMinionController _cardMinionController => this.transform.GetComponent<_CardMinionController>();

        public void OnDrop(PointerEventData eventData)
        {
          
        }

        #region --- Mouse over action ---
        public void OnPointerEnter(PointerEventData eventData)
        {
            this._cardMinionController._Base._CardMinionBackgroundModerator._ShowCardMinionShadow();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            this._cardMinionController._Base._CardMinionBackgroundModerator._HideCardMinionShadow();
        }

        #endregion
    }
}
