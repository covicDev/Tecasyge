using UnityEngine;

namespace _cov._Sword
{
    public class _SwordBase : MonoBehaviour, _ISwordBase
    {
        public _ISwordAttackBackgroundModerator _SwordAttackBackgroundModerator => this.transform.GetComponent<_SwordAttackBackgroundModerator>();
    }
    public interface _ISwordBase
    {
        _ISwordAttackBackgroundModerator _SwordAttackBackgroundModerator { get; }
    }
}
