using UnityEngine;

namespace _cov._Util._Camera
{
    public interface _ICameraController
    {
        Color _ArrowNavigationHighlightColor { get; }
        Color _ArrowNavigationNormalColor { get; }
        float _ArrowNavigationSpeed { get; }
        SpriteRenderer _BackgroundImage { get; }
        void _SetBackgroungImage(SpriteRenderer value);
        float _JumpOfCamera { get; }
        Camera _MainCamera { get; }
        float _MaxZoomValue { get; }
        float _MinZoomValue { get; }
        float _NormalZoomValue { get; }

        Vector3 _ClampCamera(Vector3 targetPosition);
    }

    public class _CameraController : MonoBehaviour, _ICameraController
    {
        #region --- Serialize field ---

        // Reference to main scene camera.
        public Camera _MainCamera => Camera.main;

        [Header("Reference to background image.")]
        [SerializeField] SpriteRenderer _backgroundImage = new SpriteRenderer();
        public SpriteRenderer _BackgroundImage => _backgroundImage;
        public void _SetBackgroungImage(SpriteRenderer value) => _backgroundImage = value;


        [Header("Camera left and right moving speed.")]
        [SerializeField] float _jumpOfCamera = .5f;
        public float _JumpOfCamera => _jumpOfCamera;


        #region -- Zoom values --
        [Header("Camera zoom values.")]
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

        #region --- Public method ---
        public Vector3 _ClampCamera(Vector3 targetPosition)
        {
            return this.transform.GetComponentInChildren<_CameraMovement>()._ClampCamera(targetPosition);
        }
        #endregion

    }
}
