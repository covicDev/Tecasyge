using UnityEngine;

namespace _cov._FieldDraw
{
    public class _FieldDrawBase : MonoBehaviour, _IFieldDrawBase
    {
        public Transform _GameManager => GameObject.Find("GameManager").transform;

        public _IFieldDrawBackgroundModerator _FieldDrawBackgroundModerator => this.transform.GetComponent<_FieldDrawBackgroundModerator>();
    }
    public interface _IFieldDrawBase
    {
        Transform _GameManager { get; }
        _IFieldDrawBackgroundModerator _FieldDrawBackgroundModerator { get; }
    }
}
