using UnityEngine;
using UnityEditor;
using UnityEngine.Assertions;

public class CarControllerTests {

    public void WheelCollidersFound() {

        // Arrange
        GameObject gameObject = new GameObject();
        GameObject collidersObject = new GameObject("carColliders");
        collidersObject.transform.parent = gameObject.transform;
        GameObject wheelObject = new GameObject("carWheels");
        wheelObject.transform.parent = gameObject.transform;
        GameObject wheel1 = new GameObject();
        wheel1.transform.parent = wheelObject.transform;
        GameObject wheel2 = new GameObject();
        wheel2.transform.parent = wheelObject.transform;

        carController controller = gameObject.AddComponent<carController>();
        controller.wheelColliders = collidersObject.GetComponentsInChildren<WheelCollider>();

        // Assert
        Assert.IsNotNull(controller.wheelColliders);
        Assert.AreEqual(2, controller.wheelColliders.Length);

    }

    public void WheelTransformsFound() {

        // Arrange
        GameObject gameObject = new GameObject();
        GameObject collidersObject = new GameObject("carColliders");
        collidersObject.transform.parent = gameObject.transform;
        GameObject wheelObject = new GameObject("carWheels");
        wheelObject.transform.parent = gameObject.transform;
        GameObject wheel1 = new GameObject();
        wheel1.transform.parent = wheelObject.transform;
        GameObject wheel2 = new GameObject();
        wheel2.transform.parent = wheelObject.transform;

        carController controller = gameObject.AddComponent<carController>();
        controller.wheelTransforms = wheelObject.GetComponentsInChildren<Transform>();

        // Assert
        Assert.IsNotNull(controller.wheelTransforms);
        Assert.AreEqual(2, controller.wheelTransforms.Length);

    }

    public void InputFound() {

        // Arrange
        GameObject gameObject = new GameObject();

        carController controller = gameObject.AddComponent<carController>();
        inputs input = gameObject.AddComponent<inputs>();
        controller.input = input;

        // Assert
        Assert.IsNotNull(controller.input);

    }

    public void RigidbodyFound() {

        // Arrange
        GameObject gameObject = new GameObject();
        Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();

        carController controller = gameObject.AddComponent<carController>();
        controller.rigidbody = rigidbody;

        // Assert
        Assert.IsNotNull(controller.rigidbody);

    }

}
