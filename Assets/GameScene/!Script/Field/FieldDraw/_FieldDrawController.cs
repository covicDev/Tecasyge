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

            // Draw new card.
            int randNumber = Random.Range(0, 3);

            // Get free pile field.
            var pileField = this._Base._FieldDrawPileModerator._GetNextFreeFieldPileTranform();

            // Draw card
            if (randNumber == 0)
            {
                var minionCard = Instantiate(this._Base._CardMinionPrefab, pileField.position, Quaternion.identity);
                minionCard.transform.SetParent(pileField);
            }
            else
            {
                var goldCard = Instantiate(this._Base._CardGoldPrefab, pileField.position, Quaternion.identity);
                goldCard.transform.SetParent(pileField);
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
