using UnityEngine;

namespace _cov._FieldDiscard
{
    public class _FieldDiscardController : MonoBehaviour, _IFieldDiscardController
    {
        public _IFieldDiscardBase _Base => this.transform.GetComponent<_FieldDiscardBase>();

        #region --- Public method ---
        public bool _DestroyCardMinion(GameObject card)
        {
            var minionScript = card.transform.GetComponent<_CardMinion._CardMinionController>();
            minionScript._TransferCardMinionToThisField(this.transform, this.transform.position, this._Base._FieldType);
            minionScript._DiscardCardMinion();
            return true;
        }

        public bool _DestroyCardGold(GameObject card)
        {
            var cardScript = card.transform.GetComponent<_CardGold._CardGoldController>();
            cardScript._TransferCardGoldToThisField(this.transform, this.transform.position, this._Base._FieldType);
            cardScript._DiscardCardGold();
            return true;
        }

        #endregion
    }
    public interface _IFieldDiscardController
    {
        _IFieldDiscardBase _Base { get; }
        bool _DestroyCardMinion(GameObject card);
        bool _DestroyCardGold(GameObject card);
    }
}
