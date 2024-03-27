using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 100f; // Adjust this to change mouse sensitivity
    public Transform playerBody; // Reference to the player's body GameObject

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen
    }

    void Update()
    {
        // Get mouse input for camera rotation
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Rotate the camera vertically (up/down) based on mouse Y input
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp rotation to prevent flipping

        // Rotate the player's body horizontally (left/right) based on mouse X input
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
