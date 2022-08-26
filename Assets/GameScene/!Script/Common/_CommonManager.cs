using UnityEngine;

namespace _cov._Common
{
    public class _CommonManager : MonoBehaviour
    {
        #region --- Instance ---
        public static _CommonManager _Instance { get; private set; }

        private void Awake()
        {
            _Instance = this;
        }

        #endregion
        public static Camera _CameraMain => Camera.main;

        [Header("Game Manager transform reference.")]
        [SerializeField] private Transform _gameManager;
        public static Transform _GameManager => _Instance._gameManager;
    }

}
