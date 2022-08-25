using UnityEngine;
using UnityEngine.UI;

namespace _cov._Sword
{
    public class _SwordAttackBackgroundModerator : MonoBehaviour, _ISwordAttackBackgroundModerator
    {
        // Image reference.
        private Image _swordAttackImage => this.transform.Find(_SSwordName._ImageName).transform.GetComponent<Image>();

        // Canvas group reference.
        private CanvasGroup _swordAttackCanvas => this.transform.GetComponent<CanvasGroup>();

        // Preparation for denial and approval interactions.
        private Color _fieldDiscardBackgroundOriginalColor;
        private Color _fieldDiscardBackgroundDenialColor = Color.red;
        private Color _fieldDiscardBackgroundApprovalColor = Color.green;

        private void Start()
        {
            this._fieldDiscardBackgroundOriginalColor = this._swordAttackImage.color;
            this._fieldDiscardBackgroundDenialColor = Color.red;
            this._fieldDiscardBackgroundApprovalColor = Color.green;
        }

        public void _ShowAttackSwordImage()
        {
            this._swordAttackCanvas.alpha = 1f;
        }
        public void _HideAttackSwordImage()
        {
            this._swordAttackCanvas.alpha = 0f;
        }
    }

    public interface _ISwordAttackBackgroundModerator
    {
        void _HideAttackSwordImage();
        void _ShowAttackSwordImage();
    }

}
