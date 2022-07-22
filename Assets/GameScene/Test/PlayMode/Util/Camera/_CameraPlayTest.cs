using NUnit.Framework;
using UnityEngine;
using NSubstitute;
using System.Reflection;

using _cov._Util._Camera;

namespace Tests
{
    public class _CameraPlayTest
    {
        private bool _debug = true;

        // In game component.
        GameObject _gameManager;
        Camera _camera;
        _CameraController _cameraController;

        #region --- SetUp ---
        [SetUp]
        public void _BeforeEachTest()
        {
            if (_debug) Debug.Log($"{MethodBase.GetCurrentMethod().Name}");

            // Settings for game scene adaptation.

            // Game manager object.
            // Some classes looks for this object by name.
            _gameManager = new GameObject("GameManager");

            // Main camera component.
            _gameManager.AddComponent<Camera>();
            _camera = _gameManager.GetComponent<Camera>();
            _camera.tag = "MainCamera";

            // Background image for testing.
            // _CameraMovement takes border values of the background.
            var background = Resources.Load("Prefab/Level/Background", typeof(GameObject)) as GameObject;
            var spriteBackground = background.GetComponent<SpriteRenderer>();

            // _CameraController component.
            _gameManager.AddComponent<_CameraController>();
            _cameraController = _gameManager.GetComponent<_CameraController>();

            // Background image needs to be given by reference, in game scene given by serialize field.
            _cameraController._SetBackgroungImage(spriteBackground);

            // _CameraMovement component.
            _gameManager.AddComponent<_CameraMovement>();
        }

        #endregion

        [Test]
        public void _0_CameraMovement_CameraClamp_Test_From_Random_Values_To_Clamped_Values()
        {
            if (_debug) Debug.Log($"{MethodBase.GetCurrentMethod().Name}");

            // Arrange
            _CameraMovement cameraMovement = _gameManager.GetComponent<_CameraMovement>();

            // Act
            float random = (float)Random.Range(-1000, 1000);
            // Sets camera position to random.
            _cameraController._MainCamera.transform.position = new Vector3(random, random);
            var oldCameraPosition = _cameraController._MainCamera.transform.position;

            // Clamp Camera action.
            _cameraController._MainCamera.transform.position = cameraMovement._ClampCamera(_cameraController._MainCamera.transform.position);

            // Assert
            Assert.AreNotEqual(oldCameraPosition, _cameraController._MainCamera.transform.position);

            // debug
            if (_debug) Debug.Log($"Start camera position: {oldCameraPosition}, after clamp: {_cameraController._MainCamera.transform.position}.");
        }

        [Test]
        public void _1_CameraZoomMovement_CameraZoomReset_Test_From_1000f_To_Normal_Zoom_Value()
        {
            if (_debug) Debug.Log($"{MethodBase.GetCurrentMethod().Name}");

            // Arrange
            // _CameraZoomMovement component.
            _gameManager.AddComponent<_CameraZoomMovement>();
            var cameraZoomMovement = _gameManager.GetComponent<_CameraZoomMovement>();

            // Act
            float startSize = 1000f;
            cameraZoomMovement._cameraControllerRef._MainCamera.orthographicSize = startSize;

            // Reset Camera action.
            cameraZoomMovement._CameraZoomReset();

            // Arrange
            Assert.AreEqual(_cameraController._NormalZoomValue, _cameraController._MainCamera.orthographicSize);

            // debug
            if (_debug) Debug.Log($"Start orthographicSize camera value: {startSize}," +
                $" normal zoom value: {_cameraController._NormalZoomValue}" +
                $" after reset: {_cameraController._MainCamera.orthographicSize}.");
        }

        [Test]
        public void _2_CameraZoomMovement_CameraZoomIn_Test_From_1000f_To_ZoomIn_Value()
        {
            if (_debug) Debug.Log($"{MethodBase.GetCurrentMethod().Name}");

            // Arrange
            // _CameraZoomMovement component.
            _gameManager.AddComponent<_CameraZoomMovement>();
            var cameraZoomMovement = _gameManager.GetComponent<_CameraZoomMovement>();

            // Act
            float startSize = 1000f;
            cameraZoomMovement._cameraControllerRef._MainCamera.orthographicSize = startSize;

            // ZoomIn Camera action.
            cameraZoomMovement._CameraZoomIn();

            // Arrange
            Assert.AreEqual(_cameraController._MinZoomValue, _cameraController._MainCamera.orthographicSize);

            // debug
            if (_debug) Debug.Log($"Start orthographicSize camera value: {startSize}," +
                $" minimum zoom value: {_cameraController._MinZoomValue}," +
                $" after zoom in: {_cameraController._MainCamera.orthographicSize}.");
        }

        [Test]
        public void _3_CameraZoomMovement_CameraZoomOut_Test_From_1000f_To_ZoomOut_Value()
        {
            if (_debug) Debug.Log($"{MethodBase.GetCurrentMethod().Name}");

            // Arrange
            // _CameraZoomMovement component.
            _gameManager.AddComponent<_CameraZoomMovement>();
            var cameraZoomMovement = _gameManager.GetComponent<_CameraZoomMovement>();

            // Act
            float startSize = 1000f;
            cameraZoomMovement._cameraControllerRef._MainCamera.orthographicSize = startSize;

            // ZoomIn Camera action.
            cameraZoomMovement._CameraZoomOut();

            // Arrange
            Assert.AreEqual(_cameraController._MaxZoomValue, _cameraController._MainCamera.orthographicSize);

            // debug
            if (_debug) Debug.Log($"Start orthographicSize camera value: {startSize}," +
                $" maximum zoom value: {_cameraController._MaxZoomValue}," +
                $" after zoom in: {_cameraController._MainCamera.orthographicSize}.");
        }
    }
}
