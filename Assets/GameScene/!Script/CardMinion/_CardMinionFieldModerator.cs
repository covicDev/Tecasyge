using UnityEngine;

using _cov._Enum;

namespace _cov._CardMinion
{
    public class _CardMinionFieldModerator : MonoBehaviour, _ICardMinionFieldModerator
    {
        private _EField _currentField = _EField.Null;

        public _EField _GetCurrentField()
        {
            return _currentField;
        }

        public bool _SetCurrentFieldTo(_EField field)
        {
            this._currentField = field;
            return true;
        }

        #region --- Check ---
        public bool __IsCardMinionOnFieldBattle()
        {
            return this._currentField == _EField.Battlefield;
        }
        #endregion
    }
    public interface _ICardMinionFieldModerator
    {
        _EField _GetCurrentField();
        bool _SetCurrentFieldTo(_EField field);
        bool __IsCardMinionOnFieldBattle();
    }

}
