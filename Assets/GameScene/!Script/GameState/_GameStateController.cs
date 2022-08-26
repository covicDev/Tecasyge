using System.Collections.Generic;
using UnityEngine;

using _cov._Enum;

namespace _cov._GameState
{
    public class _GameStateController : MonoBehaviour, _IGameStateController
    {
        public _EGameState _GameCurrentState => this.GetComponent<_GameStateManager>()._CurrentGameState;

        #region --- Variable ---
        private List<_IGameStateHandler> _observers = new List<_IGameStateHandler>();

        #endregion

        #region --- Game state handler ---
        public void _Attach(_IGameStateHandler observer)
        {
            this._observers.Add(observer);
        }
        public void _Detach(_IGameStateHandler observer)
        {
            this._observers.Remove(observer);
        }
        // Notify.
        public void _Notify()
        {
            foreach (var observer in _observers)
            {
           //     Debug.Log($"Current observer: {observer}");
                observer._UpdateGameStatus(this._GameCurrentState);
            }
        }

        #endregion
    }

    public interface _IGameStateController
    {
        _EGameState _GameCurrentState { get; }

        // Game State handlers.
        void _Attach(_IGameStateHandler observer);
        void _Detach(_IGameStateHandler observer);
        void _Notify();
    }
}
