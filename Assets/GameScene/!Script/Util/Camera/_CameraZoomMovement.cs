using UnityEngine;

namespace _cov._Util._Camera
{
    public class _CameraZoomMovement : MonoBehaviour, _ICameraZoomMovement
    {
        #region --- Variable ---
        private _CameraController _cameraControllerRef => GameObject.Find("GameManager").transform.GetComponent<_CameraController>();
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
            float size = _minZoomValue;
            this._setCameraZoom(size);
        }
        /// <summary>
        /// Camera zoom out method. Sets zoom at maximum value.
        /// </summary>
        public void _CameraZoomOut()
        {
            float size = _maxZoomValue;
            this._setCameraZoom(size);
        }
        /// <summary>
        /// Camera zoom reset method. Sets zoom at normal value.
        /// </summary>
        public void _CameraZoomReset()
        {
            float size = _normalZoomValue;
            this._setCameraZoom(size);
        }

        #endregion

        #region --- Private method ---
        private void _setCameraZoom(float size)
        {
            // check camera size.
            this._cameraControllerRef._MainCamera.orthographicSize = Mathf.Clamp(size, this._minZoomValue, this._maxZoomValue);

            // check camera position;
            this._cameraControllerRef._MainCamera.transform.position = this._cameraControllerRef._ClampCamera(this._cameraControllerRef._MainCamera.transform.position);
        }

        #endregion
    }

    public interface _ICameraZoomMovement
    {
        void _CameraZoomIn();
        void _CameraZoomOut();
        void _CameraZoomReset();
    }

}