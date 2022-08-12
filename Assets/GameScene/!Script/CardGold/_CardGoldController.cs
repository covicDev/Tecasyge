using UnityEngine;
using _cov._Enum;

namespace _cov._CardGold
{
    public class _CardGoldController : MonoBehaviour, _ICardGoldController
    {
        public _ICardGoldBase _Base => this.transform.GetComponent<_CardGoldBase>();


        #region --- Public method ---
        public bool _TransferCardGoldToThisField(Transform parent, Vector3 position, _EField field)
        {

            this.transform.SetParent(parent);
            this.transform.position = position;

            this._Base._CurrentField = field;

            this.transform.GetComponent<Canvas>().overrideSorting = true;

            return true;
        }

        public bool _DiscardCardGold()
        {
            Destroy(this.gameObject);
            return true;
        }
        #endregion
    }

    public interface _ICardGoldController
    {
        _ICardGoldBase _Base { get; }
        bool _TransferCardGoldToThisField(Transform parent, Vector3 position, _EField field);
        bool _DiscardCardGold();
    }
}
