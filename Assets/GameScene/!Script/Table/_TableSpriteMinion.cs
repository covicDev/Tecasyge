using UnityEngine;

namespace _cov._Table
{
    public class _TableSpriteMinion : MonoBehaviour
    {
        [Header("Images of minions.")]
        [SerializeField] Sprite[] _spritesOfMinons;
        public Sprite[] _SpritesOfMinons => _spritesOfMinons;
    }
}
