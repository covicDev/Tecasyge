using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using System.Reflection;

using _cov._Util._Camera;

namespace Tests
{
    public class _CameraTest
    {
        private bool _debug = true;
        [Test]
        public void _Camera_ClampCamerTest()
        {
            if (_debug) Debug.Log($"{MethodBase.GetCurrentMethod().Name}");

            // arrange
            I_CameraMovement cameraMovement = Substitute.For<I_CameraMovement>();
            var vector = new Vector3(int.MaxValue, int.MinValue);
            
            // act
            var result = cameraMovement._ClampCamera(vector);

            // assert
            Assert.AreNotEqual(vector, result);

            // debug
            if (_debug) Debug.Log($"Start vector: {vector}, end vector: {result}.");
        }

    }
}
