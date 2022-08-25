using UnityEngine;
using UnityEngine.UI;

namespace _cov._FieldHand
{
    public class _FieldHandBackgroundModerator : MonoBehaviour, _IFieldHandBackgroundModerator
    {
        #region --- Variable ---
        // Background reference.
        private Image _fieldHandBackgroundImage => this.transform.Find(_SFieldHandName._BackgroundName).transform.GetComponent<Image>();

        // Preparation for denial and approval interactions.
        private Color _fieldHandBackgroundOriginalColor;
        private Color _fieldHandBackgroundDenialColor = Color.red;
        private Color _fieldHandBackgroundApprovalColor = Color.green;

        #endregion

        private void Start()
        {
            this._fieldHandBackgroundOriginalColor = this._fieldHandBackgroundImage.color;
            this._fieldHandBackgroundDenialColor = Color.red;
            this._fieldHandBackgroundApprovalColor = Color.green;
        }

        // For card background changes.
        public void _SetBackgroundOfFieldHandDenial()
        {
            this._fieldHandBackgroundImage.color = this._fieldHandBackgroundDenialColor;
        }
        public void _SetBackgroundOfFieldHandApproval()
        {
            this._fieldHandBackgroundImage.color = this._fieldHandBackgroundApprovalColor;
        }
        public void _SetBackgroundOfFieldHandToOriginal()
        {
            this._fieldHandBackgroundImage.color = this._fieldHandBackgroundOriginalColor;
        }
    }

    public interface _IFieldHandBackgroundModerator
    {
        void _SetBackgroundOfFieldHandApproval();
        void _SetBackgroundOfFieldHandDenial();
        void _SetBackgroundOfFieldHandToOriginal();
    }
}
