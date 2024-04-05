using UnityEngine;

public class EarthController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    private bool isRotating = false;
    private Vector3 startMousePosition;

    private void Update()
    {
        if (isRotating)
        {
            //Debug.Log("Rotating");
            RotateEarth();
        }
    }

    private void RotateEarth()
    {
        Vector3 currentMousePosition = Input.mousePosition;
        Vector3 mouseMovement = currentMousePosition - startMousePosition;

        float angleX = mouseMovement.y * rotationSpeed * Time.deltaTime;
        float angleY = -mouseMovement.x * rotationSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up, angleY, Space.World);
        transform.Rotate(Vector3.right, angleX, Space.World);

        startMousePosition = currentMousePosition;
    }

    public void EarthPressed()
    {
        isRotating = true;
        startMousePosition = Input.mousePosition;
    }

    public void EarthReleased()
    {
        isRotating = false;
    }
}
