using NUnit.Framework;
using UnityEngine;
using UnityEditor.SceneManagement;


public class CameraTests
{
    [Test]
    public void TestCameraPosition()
    {
        // Arrange
        var camera = GameObject.FindObjectOfType<Camera>();
        var expectedPosition = new Vector3(8.09f, 0.81f, 17.10f);

        // Act
        var actualPosition = camera.transform.position;

        // Assert
        Assert.AreEqual(expectedPosition, actualPosition);
    }

    [Test]
    public void TestCameraFOV()
    {
        // Arrange
        var camera = GameObject.FindObjectOfType<Camera>();
        var expectedFOV = 45.6413193f;

        // Act
        var actualFOV = camera.fieldOfView;

        // Assert
        Assert.AreEqual(expectedFOV, actualFOV);
    }


}
