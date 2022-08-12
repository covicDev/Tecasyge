using UnityEngine;

namespace _cov._FieldDraw
{
    public class _FieldDrawController : MonoBehaviour, _IFieldDrawController
    {
        public _IFieldDrawBase _Base => this.transform.GetComponent<_FieldDrawBase>();

        private void Start()
        {
            // Preps for field pile slots.
            this._Base._FieldDrawPileModerator._PrepareFieldPileSlots();
        }

        #region --- Preparations ---
        #endregion

        #region --- Public method ---
        public void _GetNextCard()
        {

            // Checks is any pile field is free.
            if(this._Base._FieldDrawPileModerator.__CheckIsAnyFieldPileFree == false)
            {
                this._Base._FieldDrawBackgroundModerator._SetBackgroundOfFieldDrawDenial();
                return;
            }

            this._Base._FieldDrawBackgroundModerator._SetBackgroundOfFieldDrawApproval();

            // Draw new card.
            int randNumber = Random.Range(0, 2);

            // Get free pile field.
            var pileFieldAddon = this._Base._FieldDrawPileModerator._GetNextFreeFieldPileAddonTranform();


            // Draw card
            if (randNumber == 0)
            {
                var minionCard = Instantiate(this._Base._CardMinionPrefab, pileFieldAddon.position, Quaternion.identity);
                var minionScript = minionCard.transform.GetComponent<_CardMinion._CardMinionController>();
                minionScript._TransferCardMinionToThisField(pileFieldAddon, pileFieldAddon.position, this._Base._FieldType);
            }
            else
            {
                var goldCard = Instantiate(this._Base._CardGoldPrefab, pileFieldAddon.position, Quaternion.identity);
                goldCard.transform.SetParent(pileFieldAddon);

                goldCard.GetComponent<Canvas>().overrideSorting = true;
                var goldScript = goldCard.transform.GetComponent<_CardGold._CardGoldController>();
                goldScript._TransferCardGoldToThisField(pileFieldAddon, pileFieldAddon.position, this._Base._FieldType);
            }
           
        }
        #endregion
    }
    public interface _IFieldDrawController
    {
        _IFieldDrawBase _Base { get; }
        void _GetNextCard();
    }
}
