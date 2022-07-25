using UnityEngine;

namespace _cov._FieldBattle
{
    public class _FieldBattleManager : MonoBehaviour, _IFieldBattleManager
    {
        [SerializeField] private Sprite _spriteFieldBattleToBuy;
        [SerializeField] private Sprite _spriteFieldBattle;
        public Sprite _SpriteFieldBattleToBuy => _spriteFieldBattleToBuy;
        public Sprite _SpriteFieldBattle => _spriteFieldBattle;
    }
    public interface _IFieldBattleManager
    {

    }
}
