using UnityEngine;

namespace _cov._Sword
{
    public class _SwordAttackController : MonoBehaviour, _ISwordAttackController
    {
        public _ISwordBase _Base => this.transform.GetComponent<_SwordBase>();

        public void _ShowSwordAttack() => this._Base._SwordAttackBackgroundModerator._ShowAttackSwordImage();
        public void _HideSwordAttack() => this._Base._SwordAttackBackgroundModerator._HideAttackSwordImage();
    }
    public interface _ISwordAttackController
    {
        _ISwordBase _Base { get; }

        void _ShowSwordAttack();
        void _HideSwordAttack();

    }
}
