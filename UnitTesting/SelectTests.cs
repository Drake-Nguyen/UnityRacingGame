using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;

public class CarSelectionManagerTests
{
    [Test]
    public void TestRight()
    {
        // Arrange
        var go = new GameObject();
        var carSelectionManager = go.AddComponent<CarSelectionManager>();
        var mapImage1Go = new GameObject();
        var mapImage1 = mapImage1Go.AddComponent<Image>();
        var mapImage2Go = new GameObject();
        var mapImage2 = mapImage2Go.AddComponent<Image>();
        carSelectionManager.mapImages = new Image[]{mapImage1, mapImage2};
        carSelectionManager.cars = new GameObject[2];
        carSelectionManager.cars[0] = new GameObject();
        carSelectionManager.cars[1] = new GameObject();
        carSelectionManager.currentCar = 0;

        // Act
        carSelectionManager.Right();

        // Assert
        Assert.AreEqual(1, carSelectionManager.currentCar);
        Assert.IsTrue(carSelectionManager.cars[0].activeSelf == false && carSelectionManager.cars[1].activeSelf == true);
        Assert.IsTrue(carSelectionManager.mapImages[0].gameObject.activeSelf == false && carSelectionManager.mapImages[1].gameObject.activeSelf == true);

        // Clean up
        Object.DestroyImmediate(go);
        Object.DestroyImmediate(mapImage1Go);
        Object.DestroyImmediate(mapImage2Go);
    }

    [Test]
    public void TestLeft()
    {
        // Arrange
        var go = new GameObject();
        var carSelectionManager = go.AddComponent<CarSelectionManager>();
        var mapImage1Go = new GameObject();
        var mapImage1 = mapImage1Go.AddComponent<Image>();
        var mapImage2Go = new GameObject();
        var mapImage2 = mapImage2Go.AddComponent<Image>();
        carSelectionManager.mapImages = new Image[]{mapImage1, mapImage2};
        carSelectionManager.cars = new GameObject[2];
        carSelectionManager.cars[0] = new GameObject();
        carSelectionManager.cars[1] = new GameObject();
        carSelectionManager.currentCar = 1;

        // Act
        carSelectionManager.Left();

        // Assert
        Assert.AreEqual(0, carSelectionManager.currentCar);
        Assert.IsTrue(carSelectionManager.cars[0].activeSelf == true && carSelectionManager.cars[1].activeSelf == false);
        Assert.IsTrue(carSelectionManager.mapImages[0].gameObject.activeSelf == true && carSelectionManager.mapImages[1].gameObject.activeSelf == false);

        // Clean up
        Object.DestroyImmediate(go);
        Object.DestroyImmediate(mapImage1Go);
        Object.DestroyImmediate(mapImage2Go);
    }

}
