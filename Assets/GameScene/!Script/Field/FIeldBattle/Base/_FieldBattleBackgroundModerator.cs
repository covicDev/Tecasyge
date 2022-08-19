using UnityEngine;
using UnityEngine.UI;

namespace _cov._FieldBattle
{
    public class _FieldBattleBackgroundModerator : MonoBehaviour, _IFieldBattleBackgroundModerator
    {
        #region --- Variable ---
        // Background reference.
        private Image _fieldBattleBackgroundImage => this.transform.Find(_SFieldBattleName._BackgroundName).transform.GetComponent<Image>();
        // Shadow as a canvas group.
        private CanvasGroup _fieldBattleShadowImageCanvas => this.transform.Find(_SFieldBattleName._ShadowName).transform.GetComponent<CanvasGroup>();

        // Preparation for denial and approval interactions.
        private Color _fieldBattleBackgroundOriginalColor;
        private Color _fieldBattleBackgroundDenialColor = Color.red;
        private Color _fieldBattleBackgroundApprovalColor = Color.green;

        #endregion

        private void Start()
        {
            this._fieldBattleBackgroundOriginalColor = this._fieldBattleBackgroundImage.color;
            this._fieldBattleBackgroundDenialColor = Color.red;
            this._fieldBattleBackgroundApprovalColor = Color.green;
        }

        // For card background changes.
        public void _SetBackgroundOfFieldBattleDenial()
        {
            this._fieldBattleBackgroundImage.color = this._fieldBattleBackgroundDenialColor;
        }
        public void _SetBackgroundOfFieldBattleApproval()
        {
            this._fieldBattleBackgroundImage.color = this._fieldBattleBackgroundApprovalColor;
        }
        public void _SetBackgroundOfFieldBattleToOriginal()
        {
            this._fieldBattleBackgroundImage.color = this._fieldBattleBackgroundOriginalColor;
        }
        public void _ShowFieldBattleShadow()
        {
            this._fieldBattleShadowImageCanvas.alpha = 1f;
        }
        public void _HideFieldBattleShadow()
        {
            this._fieldBattleShadowImageCanvas.alpha = 0f;
        }
    }

    public interface _IFieldBattleBackgroundModerator
    {
        void _SetBackgroundOfFieldBattleDenial();
        void _SetBackgroundOfFieldBattleApproval();
        void _SetBackgroundOfFieldBattleToOriginal();
        void _ShowFieldBattleShadow();
        void _HideFieldBattleShadow();
    }


}