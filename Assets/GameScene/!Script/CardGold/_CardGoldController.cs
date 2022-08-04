using UnityEngine;

namespace _cov._CardGold
{
    public class _CardGoldController : MonoBehaviour, _ICardGoldController
    {
        public _ICardGoldBase _Base => this.transform.GetComponent<_CardGoldBase>();
    }

    public interface _ICardGoldController
    {
        _ICardGoldBase _Base { get; }
    }
}
