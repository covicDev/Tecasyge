using UnityEngine;

namespace _cov._FieldDraw
{
    public class _FieldDrawController : MonoBehaviour, _IFieldDrawController
    {
        public _IFieldDrawBase _Base => this.transform.GetComponent<_FieldDrawBase>();

    }
    public interface _IFieldDrawController
    {
        _IFieldDrawBase _Base { get; }
    }
}
