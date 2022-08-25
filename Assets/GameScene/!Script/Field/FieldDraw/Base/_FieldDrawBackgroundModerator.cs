using UnityEngine;
using UnityEngine.UI;


namespace _cov._FieldDraw
{
    public class _FieldDrawBackgroundModerator : MonoBehaviour, _IFieldDrawBackgroundModerator
    {
        #region --- Variable ---
        // Background reference.
        private Image _fieldDrawBackgroundImage => this.transform.Find(_SFieldDrawName._BackgroundName).transform.GetComponent<Image>();
        // Shadow as a canvas group.
        private CanvasGroup _fieldDrawShadowImageCanvas => this.transform.Find(_SFieldDrawName._ShadowName).transform.GetComponent<CanvasGroup>();

        // Background canvas group.
        private CanvasGroup _fieldDrawImageCanvas => this.transform.GetComponent<CanvasGroup>();

        // Preparation for denial and approval interactions.
        private Color _fieldDrawBackgroundOriginalColor;
        private Color _fieldDrawBackgroundDenialColor = Color.red;
        private Color _fieldDrawBackgroundApprovalColor = Color.green;

        #endregion

        private void Start()
        {
            this._fieldDrawBackgroundOriginalColor = this._fieldDrawBackgroundImage.color;
            this._fieldDrawBackgroundDenialColor = Color.red;
            this._fieldDrawBackgroundApprovalColor = Color.green;
        }

        // For card background changes.
        public void _SetBackgroundOfFieldDrawDenial()
        {
            this._fieldDrawBackgroundImage.color = this._fieldDrawBackgroundDenialColor;
        }
        public void _SetBackgroundOfFieldDrawApproval()
        {
            this._fieldDrawBackgroundImage.color = this._fieldDrawBackgroundApprovalColor;
        }
        public void _SetBackgroundOfFieldDrawToOriginal()
        {
            this._fieldDrawBackgroundImage.color = this._fieldDrawBackgroundOriginalColor;
            this._fieldDrawImageCanvas.alpha = 1f;
        }
        public void _ShowFieldDrawShadow()
        {
            this._fieldDrawShadowImageCanvas.alpha = 1f;
        }
        public void _HideFieldDrawShadow()
        {
            this._fieldDrawShadowImageCanvas.alpha = 0f;
        }
        public void _SetBackgroundOfFieldDrawToGrey()
        {
            this._fieldDrawImageCanvas.alpha = 0.7f;
        }
    }

    public interface _IFieldDrawBackgroundModerator
    {
        void _SetBackgroundOfFieldDrawDenial();
        void _SetBackgroundOfFieldDrawApproval();
        void _SetBackgroundOfFieldDrawToOriginal();
        void _ShowFieldDrawShadow();
        void _HideFieldDrawShadow();
        void _SetBackgroundOfFieldDrawToGrey();
    }
}

