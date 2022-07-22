using UnityEngine;

namespace _cov._Util._Camera
{
    public class _CameraZoomMovement : MonoBehaviour, _ICameraZoomMovement
    {
        #region --- Variable ---
        public _ICameraController _cameraControllerRef => GameObject.Find("GameManager").transform.GetComponentInChildren<_CameraController>();
        private Camera _mainCameraRef => this._cameraControllerRef._MainCamera;
        private float _minZoomValue => this._cameraControllerRef._MinZoomValue;
        private float _maxZoomValue => this._cameraControllerRef._MaxZoomValue;
        private float _normalZoomValue => this._cameraControllerRef._NormalZoomValue;

        #endregion

        #region --- Public method ---
        /// <summary>
        /// Camera zoom in method. Sets zoom at minimum value.
        /// </summary>
        public void _CameraZoomIn()
        {
            float size = this._minZoomValue;
            this._setCameraZoom(size);
        }
        /// <summary>
        /// Camera zoom out method. Sets zoom at maximum value.
        /// </summary>
        public void _CameraZoomOut()
        {
            float size = this._maxZoomValue;
            this._setCameraZoom(size);
        }
        /// <summary>
        /// Camera zoom reset method. Sets zoom at normal value.
        /// </summary>
        public void _CameraZoomReset()
        {
            float size = this._normalZoomValue;
            this._setCameraZoom(size);
        }

        #endregion

        #region --- Private method ---
        private void _setCameraZoom(float size)
        {
            // check camera size.
            this._mainCameraRef.orthographicSize = Mathf.Clamp(size, this._minZoomValue, this._maxZoomValue);

            // check camera position;
            this._mainCameraRef.transform.position = this._cameraControllerRef._ClampCamera(this._mainCameraRef.transform.position);
        }

        #endregion
    }

    public interface _ICameraZoomMovement
    {
        _ICameraController _cameraControllerRef { get; }
        void _CameraZoomIn();
        void _CameraZoomOut();
        void _CameraZoomReset();
    }

}