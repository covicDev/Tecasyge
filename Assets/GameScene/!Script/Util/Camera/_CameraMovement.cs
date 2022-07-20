using UnityEngine;

namespace _cov._Util._Camera
{
    public interface I_CameraMovement
    {
        void _CameraReset();
        Vector3 _ClampCamera(Vector3 targetPosition);
    }

    public class _CameraMovement : MonoBehaviour, I_CameraMovement
    {
        #region --- Serialize field ---
        // Background for camera.
        [SerializeField] SpriteRenderer _backgroundImage;
        private float mapMinX, mapMaxX, mapMinY, mapMaxY;

        // Jump of camera in order to action.
        [SerializeField] float _jumpOfCamera = .5f;

        // Camera zoom speed.
        [SerializeField] private float _zoomSpeed = 5f;

        // Camera customs.
        [SerializeField] private float _minZoomValue = 4f;
        [SerializeField] private float _maxZoomValue = 6f;
        [SerializeField] private float _resetZoomValue = 5f;

        #endregion

        #region --- Variable ---
        // Main camera reference.
        private Camera _camera;

        // For camera coordinates. 
        private Vector3 _originPosition;
        private Vector3 _differenceBetweenPosition;

        // While drugging.
        private bool __drag = false;

        #endregion

        #region --- Default method ---
        private void Awake()
        {
            mapMinX = _backgroundImage.transform.position.x - _backgroundImage.bounds.size.x / 2f;
            mapMaxX = _backgroundImage.transform.position.x + _backgroundImage.bounds.size.x / 2f;
            mapMinY = _backgroundImage.transform.position.y - _backgroundImage.bounds.size.y / 2f;
            mapMaxY = _backgroundImage.transform.position.y + _backgroundImage.bounds.size.y / 2f;
        }
        void Start()
        {
            _camera = Camera.main;
            Debug.Log($"this._camera.orthographicSize: {this._camera.orthographicSize}");
        }
        void FixedUpdate()
        {
            #region Action for mouse wheel
            if (Input.GetAxis("Mouse ScrollWheel") > 0f) // go forward
            {
                this._goRight();
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f) // go backward
            {
                this._goLeft();
            }
            #endregion
        }
        private void LateUpdate()
        {
            // If middle mouse clicked then reset camera.
            if (Input.GetMouseButton(2))
            {
                this._CameraReset();
            }

            // If mouse right button pressed then move camera.
            if (Input.GetMouseButton(1))
            {
                this._differenceBetweenPosition = (this._camera.ScreenToWorldPoint(Input.mousePosition)) - this._camera.transform.position;
                if (this.__drag == false)
                {
                    this.__drag = true;
                    _originPosition = this._camera.ScreenToWorldPoint(Input.mousePosition);
                }
            }
            else
            {
                this.__drag = false;
            }

            if (__drag == true)
            {
                this._camera.transform.position = _originPosition - _differenceBetweenPosition;
                this._camera.transform.position = this._ClampCamera(this._camera.transform.position);
            }
        }
        #endregion

        #region --- Public method ---
        /// <summary>
        /// Method validates coordinates of camera.
        /// </summary>
        /// <param name="targetPosition">Camera current position.</param>
        /// <returns></returns>
        public Vector3 _ClampCamera(Vector3 targetPosition)
        {
            float camHeight = this._camera.orthographicSize;
            float camWidth = this._camera.orthographicSize * this._camera.aspect;

            float minX = mapMinX + camWidth;
            float maxX = mapMaxX - camWidth;

            float maxY = mapMaxY - camHeight;                                                                      
            float minY = mapMinY + camHeight;        
            
            float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
            float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

            float zPosition = targetPosition.z;

            return new Vector3(newX, newY, zPosition);
        }

        /// <summary>
        /// Method resets camera position.
        /// </summary>
        public void _CameraReset()
        {
            Mathf.Clamp(this._resetZoomValue, this._minZoomValue, this._maxZoomValue);

            // Reset the position of camera.
            this._camera.transform.position = Vector3.zero;

            // Reset the size of camera.
            this._camera.orthographicSize = this._resetZoomValue;
        }

        #endregion

        #region --- Private method ---
        // Moves camera to the right.
        private void _goRight()
        {
            float jump = this._jumpOfCamera;
            this._camera.transform.Translate(Vector3.right * jump);
            this._camera.transform.position = this._ClampCamera(this._camera.transform.position);
        }
        // Moves camera to the left.
        private void _goLeft()
        {
            float jump = this._jumpOfCamera;
            this._camera.transform.Translate(Vector3.left * jump);
            this._camera.transform.position = this._ClampCamera(this._camera.transform.position);
        }

        #endregion
    }
}
