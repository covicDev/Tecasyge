using UnityEngine;
using UnityEngine.UI;

namespace _cov._CardGold
{
    public class _CardGoldBackgroundModerator : MonoBehaviour, _ICardGoldBackgroundModerator
    {
        #region --- Variable ---
        // Background reference.
        private Image _cardGoldBackgroundImage => this.transform.Find(_SCardGoldName._BackgroundName).transform.GetComponent<Image>();
        // Shadow as a canvas group.
        private CanvasGroup _cardGoldShadowImageCanvas => this.transform.Find(_SCardGoldName._ShadowName).transform.GetComponent<CanvasGroup>();

        // Preparation for denial and approval interactions.
        private Color _cardGoldBackgroundOriginalColor;
        private Color _cardGoldBackgroundDenialColor = Color.red;
        private Color _cardGoldBackgroundApprovalColor = Color.green;
        private Color _cardGoldBackgroundDiscardColor = Color.grey;

        #endregion

        private void Start()
        {
            this._cardGoldBackgroundOriginalColor = this._cardGoldBackgroundImage.color;
            this._cardGoldBackgroundDenialColor = Color.red;
            this._cardGoldBackgroundApprovalColor = Color.green;
        }

        // For card background changes.
        public void _SetBackgroundOfCardGoldDenial()
        {
            this._cardGoldBackgroundImage.color = this._cardGoldBackgroundDenialColor;
        }
        public void _SetBackgroundOfCardGoldApproval()
        {
            this._cardGoldBackgroundImage.color = this._cardGoldBackgroundApprovalColor;
        }
        public void _SetBackgroundOfCardGoldToOriginal()
        {
            this._cardGoldBackgroundImage.color = this._cardGoldBackgroundOriginalColor;
        }
        public void _ShowCardGoldShadow()
        {
            this._cardGoldShadowImageCanvas.alpha = 1f;
        }
        public void _HideCardGoldShadow()
        {
            this._cardGoldShadowImageCanvas.alpha = 0f;
        }
        public void _SetBackgroundOfCardGoldToGray()
        {
            this._cardGoldBackgroundImage.color = this._cardGoldBackgroundDiscardColor;
        }
    }

    public interface _ICardGoldBackgroundModerator
    {
        void _HideCardGoldShadow();
        void _SetBackgroundOfCardGoldApproval();
        void _SetBackgroundOfCardGoldDenial();
        void _SetBackgroundOfCardGoldToOriginal();
        void _ShowCardGoldShadow();
        void _SetBackgroundOfCardGoldToGray();
    }

}
