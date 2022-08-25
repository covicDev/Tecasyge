using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using _cov._Enum;

namespace _cov._GameState
{

    public class _GameStateManager : MonoBehaviour, _IGameStateManager
    {
        #region --- Variable ---
        [Header("Sets reference to the state buttons.")]
        [SerializeField] private Transform _DrawButton;
        [SerializeField] private Transform _PlaceButton;
        [SerializeField] private Transform _AttackButton;
        [SerializeField] private Transform _EndTurnButton;

        [Header("Sets current game state.")]
        [SerializeField] private _EGameState _currentGameState;
        public _EGameState _CurrentGameState => this._currentGameState;

        private _IGameStateController _GameStateController => this.transform.GetComponent<_IGameStateController>();

        private List<Transform> _buttonList = new List<Transform>();
        private List<Color> _originalColorOfButton = new List<Color>();

        #endregion

        private void Start()
        {
            _buttonList.Add(this._DrawButton);
            _buttonList.Add(this._PlaceButton);
            _buttonList.Add(this._AttackButton);
            _buttonList.Add(this._EndTurnButton);

            _originalColorOfButton.Add(this._DrawButton.transform.GetComponent<Image>().color);
            _originalColorOfButton.Add(this._PlaceButton.transform.GetComponent<Image>().color);
            _originalColorOfButton.Add(this._AttackButton.transform.GetComponent<Image>().color);
            _originalColorOfButton.Add(this._EndTurnButton.transform.GetComponent<Image>().color);
        }

        #region --- Draw action ---
        public void _GameStateDraw()
        {
            this._resetColorOfButtons();
            this._currentGameState = _EGameState.Draw;
            _DrawButton.transform.GetComponent<Image>().color = Color.green;
            _GameStateController._Notify();
        }

        public void _DrawMouseOver()
        {
            this._resetColorOfButtons();
            _DrawButton.transform.GetComponent<Image>().color = Color.gray;
        }

        #endregion

        #region --- Place action ---
        public void _GameStatePlace()
        {
            this._resetColorOfButtons();
            this._currentGameState = _EGameState.Place;
            _PlaceButton.transform.GetComponent<Image>().color = Color.green;

            _GameStateController._Notify();
        }
        public void _PlaceMouseOver()
        {
            this._resetColorOfButtons();
            _PlaceButton.transform.GetComponent<Image>().color = Color.gray;
        }

        #endregion

        #region --- Attack action ---
        public void _GameStateAttack()
        {
            this._resetColorOfButtons();
            this._currentGameState = _EGameState.Attack;
            _AttackButton.transform.GetComponent<Image>().color = Color.green;

            _GameStateController._Notify();
        }
        public void _AttackMouseOver()
        {
            this._resetColorOfButtons();
            _AttackButton.transform.GetComponent<Image>().color = Color.gray;
        }

        #endregion

        #region --- End action ---
        public void _GameStateEndTurn()
        {
            this._resetColorOfButtons();
            this._currentGameState = _EGameState.End;
            _EndTurnButton.transform.GetComponent<Image>().color = Color.green;

            _GameStateController._Notify();
        }
        public void _EndTurnMouseOver()
        {
            this._resetColorOfButtons();
            _EndTurnButton.transform.GetComponent<Image>().color = Color.gray;
        }

        #endregion

        public void _MouseExitAllButton()
        {
            this._resetColorOfButtons();
        }

        #region --- Private method ---
        private void _resetColorOfButtons()
        {
            int i = 0;
            foreach (var item in _buttonList)
            {
                item.transform.GetComponent<Image>().color = this._originalColorOfButton[i++];
            }

            // Color of current button state stays green.
            switch (this._currentGameState)
            {
                case _EGameState.Draw:
                    _DrawButton.transform.GetComponent<Image>().color = Color.green;
                    break;
                case _EGameState.Place:
                    _PlaceButton.transform.GetComponent<Image>().color = Color.green;
                    break;
                case _EGameState.Attack:
                    _AttackButton.transform.GetComponent<Image>().color = Color.green;
                    break;
                case _EGameState.End:
                    _EndTurnButton.transform.GetComponent<Image>().color = Color.green;
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
    public interface _IGameStateManager
    {
        _EGameState _CurrentGameState { get; }

        void _AttackMouseOver();
        void _DrawMouseOver();
        void _EndTurnMouseOver();
        void _GameStateAttack();
        void _GameStateDraw();
        void _GameStateEndTurn();
        void _GameStatePlace();
        void _MouseExitAllButton();
        void _PlaceMouseOver();
    }
}

