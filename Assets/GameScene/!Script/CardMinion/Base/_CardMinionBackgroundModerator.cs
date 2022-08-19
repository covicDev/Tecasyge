using UnityEngine;
using UnityEngine.UI;

namespace _cov._CardMinion
{
    public class _CardMinionBackgroundModerator : MonoBehaviour, _ICardMinionBackgroundModerator
    {
        #region --- Variable ---
        // Background reference.
        private Image _cardMinionBackgroundImage => this.transform.Find(_SCardMinonName._BackgroundName).transform.GetComponent<Image>();
        
        // Shadow as a canvas group.
        private CanvasGroup _cardMinionShadowImageCanvas => this.transform.Find(_SCardMinonName._ShadowName).transform.GetComponent<CanvasGroup>();
        
        // Preparation for denial and approval interactions.
        private Color _cardMinionBackgroundOriginalColor;
        private Color _cardMinionBackgroundDenialColor = Color.red;
        private Color _cardMinionBackgroundApprovalColor = Color.green;
        private Color _cardMinionBackgroundDiscardColor = Color.grey;
        
        #endregion

        private void Start()
        {
            this._cardMinionBackgroundOriginalColor = this._cardMinionBackgroundImage.color;
            this._cardMinionBackgroundDenialColor = Color.red;
            this._cardMinionBackgroundApprovalColor = Color.green;
        }

        // For card background changes.
        public void _SetBackgroundOfCardMinionDenial()
        {
            this._cardMinionBackgroundImage.color = this._cardMinionBackgroundDenialColor;
        }
        public void _SetBackgroundOfCardMinionApproval()
        {
            this._cardMinionBackgroundImage.color = this._cardMinionBackgroundApprovalColor;
        }
        public void _SetBackgroundOfCardMinionToOriginal()
        {
            this._cardMinionBackgroundImage.color = this._cardMinionBackgroundOriginalColor;
        }
        public void _ShowCardMinionShadow()
        {
            this._cardMinionShadowImageCanvas.alpha = 1f;
        }
        public void _HideCardMinionShadow()
        {
            this._cardMinionShadowImageCanvas.alpha = 0f;
        }

        public void _SetBackgroundOfCardMinionToGray()
        {
            this._cardMinionBackgroundImage.color = this._cardMinionBackgroundDiscardColor;
        }
    }

    public interface _ICardMinionBackgroundModerator
    {
        void _SetBackgroundOfCardMinionDenial();
        void _SetBackgroundOfCardMinionApproval();
        void _SetBackgroundOfCardMinionToOriginal();
        void _ShowCardMinionShadow();
        void _HideCardMinionShadow();
        void _SetBackgroundOfCardMinionToGray();
    }
}
