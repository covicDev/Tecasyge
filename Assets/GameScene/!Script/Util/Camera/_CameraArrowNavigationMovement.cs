using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _cov._Util._Camera
{
    public class _CameraArrowNavigationMovement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        #region --- Variable ---

        #region -- Serialize Field --
        [Header("Direction of the arrow move.")]
        [SerializeField] private _ECameraArrowNavigationDirection _directionOfTheMove;

        #endregion
        // Camera controller reference.
        private _CameraController _cameraControllerRef => GameObject.Find("GameManager").transform.GetComponent<_CameraController>();

        // Checks if mouse is over.
        private bool __onHover = false;

        // Custom
        private Vector3 _direction;
        private float _jump => this._cameraControllerRef._ArrowNavigationSpeed;
        // Arrow image reference.
        private Image _image => this.transform.GetComponent<Image>();
        // Default arrows color.
        private Color _colorNormal => this._cameraControllerRef._ArrowNavigationNormalColor;
        private Color _colorHighlight => this._cameraControllerRef._ArrowNavigationHighlightColor;
        
        #endregion

        #region --- Default method ---
        private void Start()
        {
            switch (this._directionOfTheMove)
            {
                case _ECameraArrowNavigationDirection.Left:
                    this._direction = Vector3.left;
                    break;
                case _ECameraArrowNavigationDirection.Right:
                    this._direction = Vector3.right;
                    break;
                case _ECameraArrowNavigationDirection.Up:
                    this._direction = Vector3.up;
                    break;
                case _ECameraArrowNavigationDirection.Down:
                    this._direction = Vector3.down;
                    break;
                default:
                    throw new System.Exception("0x0001 Direction error.");
            }
        }

        private void FixedUpdate()
        {
            if (this.__onHover)
            {
                _cameraControllerRef._MainCamera.transform.Translate(_direction * _jump);
                _cameraControllerRef._MainCamera.transform.position = _cameraControllerRef._ClampCamera(_cameraControllerRef._MainCamera.transform.position);
            }
        }

        #endregion

        #region --- Mouse action ---
        public void OnPointerEnter(PointerEventData eventData)
        {
            this.__onHover = true;
            this._image.color = this._colorHighlight;
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            this.__onHover = false;
            this._image.color = this._colorNormal;
        }
        #endregion
    }
    public enum _ECameraArrowNavigationDirection
    {
        Left,
        Right,
        Up,
        Down
    }
}
