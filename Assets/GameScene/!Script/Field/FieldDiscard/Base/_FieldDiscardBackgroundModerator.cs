using UnityEngine;
using UnityEngine.UI;

namespace _cov._FieldDiscard
{
    public class _FieldDiscardBackgroundModerator : MonoBehaviour, _IFieldDiscardBackgroundModerator
    {
        #region --- Variable ---
        // Background reference.
        private Image _fieldDiscardBackgroundImage => this.transform.Find(_SFieldDiscardName._BackgroundName).transform.GetComponent<Image>();
        // Shadow as a canvas group.
        private CanvasGroup _fieldDiscardShadowImageCanvas => this.transform.Find(_SFieldDiscardName._ShadowName).transform.GetComponent<CanvasGroup>();

        // Preparation for denial and approval interactions.
        private Color _fieldDiscardBackgroundOriginalColor;
        private Color _fieldDiscardBackgroundDenialColor = Color.red;
        private Color _fieldDiscardBackgroundApprovalColor = Color.green;

        #endregion

        private void Start()
        {
            this._fieldDiscardBackgroundOriginalColor = this._fieldDiscardBackgroundImage.color;
            this._fieldDiscardBackgroundDenialColor = Color.red;
            this._fieldDiscardBackgroundApprovalColor = Color.green;
        }

        // For card background changes.
        public void _SetBackgroundOfFieldDiscardDenial()
        {
            this._fieldDiscardBackgroundImage.color = this._fieldDiscardBackgroundDenialColor;
        }
        public void _SetBackgroundOfFieldDiscardApproval()
        {
            this._fieldDiscardBackgroundImage.color = this._fieldDiscardBackgroundApprovalColor;
        }
        public void _SetBackgroundOfFieldDiscardToOriginal()
        {
            this._fieldDiscardBackgroundImage.color = this._fieldDiscardBackgroundOriginalColor;
        }
        public void _ShowFieldDiscardShadow()
        {
            this._fieldDiscardShadowImageCanvas.alpha = 1f;
        }
        public void _HideFieldDiscardShadow()
        {
            this._fieldDiscardShadowImageCanvas.alpha = 0f;
        }
    }

    public interface _IFieldDiscardBackgroundModerator
    {
        void _SetBackgroundOfFieldDiscardDenial();
        void _SetBackgroundOfFieldDiscardApproval();
        void _SetBackgroundOfFieldDiscardToOriginal();
        void _ShowFieldDiscardShadow();
        void _HideFieldDiscardShadow();
    }
}
