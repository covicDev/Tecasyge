using UnityEngine;

namespace _cov._Util._Camera
{
    public class _CameraController : MonoBehaviour
    {
        #region --- Serialize field ---
        [Header("Reference to background image.")]
        [SerializeField] SpriteRenderer _backgroundImage;
        public SpriteRenderer _BackgroundImage => _backgroundImage;


        [Header("Camera left and right moving speed.")]
        [SerializeField] float _jumpOfCamera = .5f;
        public float _JumpOfCamera => _jumpOfCamera;

        #region -- Zoom values --
        [Header("Camera zoom speed.")]
        [SerializeField] private float _zoomSpeed = 5f;
        public float _ZoomSpeed => _zoomSpeed;
        // Camera customs.
        [SerializeField] private float _minZoomValue = 4f;
        public float _MinZoomValue => _minZoomValue;
        [SerializeField] private float _maxZoomValue = 6f;
        public float _MaxZoomValue => _maxZoomValue;
        [SerializeField] private float _normalZoomValue = 5f;
        public float _NormalZoomValue => _normalZoomValue;
        #endregion

        #region -- Arrow navigation values --
        [Header("Arrow navigation move speed.")]
        [SerializeField] float _arrowNavigationSpeed = 1f;
        public float _ArrowNavigationSpeed => _arrowNavigationSpeed;
        [SerializeField] Color _arrowNavigationNormalColor;
        public Color _ArrowNavigationNormalColor => _arrowNavigationNormalColor;
        [SerializeField] Color _arrowNavigationHighlightColor;
        public Color _ArrowNavigationHighlightColor => _arrowNavigationHighlightColor;
        #endregion

        #endregion
    }
}
