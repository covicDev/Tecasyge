using UnityEngine;

using _cov._Enum;
using _cov._GameState;

namespace _cov._CardMinion
{
    public class _CardMinionController : MonoBehaviour, _ICardMinionController, _IGameStateHandler
    {
        public _ICardMinionBase _Base => this.transform.GetComponent<_CardMinionBase>();

        #region --- Serialize fields ---
        [Tooltip("It needs references to sprite object which contains following sprites.")]
        [Header("Graphic's sprite objects:")]
        [Space(10)]
        [SerializeField] GameObject _PortraitSprite;
        [SerializeField] GameObject _AttackValueSprite;
        [SerializeField] GameObject _LifeValueSprite;
        [SerializeField] GameObject _ArmorValueSprite;
        [SerializeField] GameObject _GoldValueSprite;

        #endregion

        private void Start()
        {
            // Attach as a Game state handler.
            var gameStateController = this._Base._GameManager.GetComponentInChildren<_GameStateController>();
            gameStateController._Attach(this);
            this._Base._GameCurrentState = gameStateController._GameCurrentState;

            // Preparation for stats moderator.
            _Base._CardMinionStatsModerator._PrepareCardMinionBasisStats();

            // Preparation for graphic adapter.
            _prepareCardGraphicAdapter();
        }

        private void OnDestroy()
        {
            // Detach as a Game state handler.
            GameObject.Find("GameManager").transform.GetComponentInChildren<_GameStateController>()._Detach(this);
        }

        #region --- Private method ---

        #region --- Preparations ---

        /// <summary>
        /// Method prepares basis stats for graphic adapter.
        /// </summary>
        private void _prepareCardGraphicAdapter()
        {
            // Sets references to spite values.
            this._Base._CardMinionGraphicAdapter._SetReferencesToValueSprites(
            _AttackValueSprite,
            _LifeValueSprite,
            _ArmorValueSprite,
            _GoldValueSprite,
            _PortraitSprite
                );

            // Sets the start values of minion.
            this._Base._CardMinionGraphicAdapter._SetStartValues(this._Base._CardMinionStatsModerator._GetCurrentStatsStruct());

            // Sets the sprites of numbers.
            var data = this._Base._CardMinionManager._TableOfMinionSprites;
            this._Base._CardMinionGraphicAdapter._SetNormalNumber(sprites: data._SpriteNormalNumber);
            this._Base._CardMinionGraphicAdapter._SetUnderNumber(sprites: data._SpriteUnderNumber);
            this._Base._CardMinionGraphicAdapter._SetOverNumber(sprites: data._SpriteOverNumber);
            this._Base._CardMinionGraphicAdapter._SetWrongNumber(sprites: data._SpriteWrongNumber);

            // Start first render
            this._Base._CardMinionGraphicAdapter._FirstRender();
        }
        #endregion

        #endregion

        #region --- Public method ---

        public bool _TransferCardMinionToThisField(Transform parent, Vector3 position, _EField field)
        {
            return this._Base._CardMinionTransferModerator._TransferCardMinionToThisField(parent, position, field);
        }

        public bool _DiscardCardMinion()
        {
           // this._Base._GameManager.GetComponentInChildren<_GameStateController>()._Detach(this);
            Destroy(this.gameObject);
            return true;
        }

        // As a handler.
        public void _UpdateGameStatus(_EGameState currentGameState)
        {
            this._Base._GameCurrentState = currentGameState;
        }

        // Checks.
        public bool _CheckIfCardMinionCanBeTransferedToThisField(_EField field)
        {
            return this._Base._CardMinionTransferModerator._CheckIfCardMinionCanBeTransferedToThisField(field);
        }

        // Sets.
        public void _SetCardMinionBackgroundToGray() => this._Base._CardMinionBackgroundModerator._SetBackgroundOfCardMinionToGray();
        public void _SetCardMinionBackgroundToOriginal() => this._Base._CardMinionBackgroundModerator._SetBackgroundOfCardMinionToOriginal();


        #endregion

    }

    public interface _ICardMinionController
    {
        _ICardMinionBase _Base { get; }

        bool _TransferCardMinionToThisField(Transform parent, Vector3 position, _EField field);
        bool _DiscardCardMinion();

        //Checks.
        bool _CheckIfCardMinionCanBeTransferedToThisField(_EField field);

        // Sets.
        void _SetCardMinionBackgroundToGray();
        void _SetCardMinionBackgroundToOriginal();

    }
}
