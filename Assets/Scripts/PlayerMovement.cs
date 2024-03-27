using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f; // Adjust this to change normal walking speed
    public float sprintSpeed = 10f; // Adjust this to change sprinting speed

    private float currentSpeed;

    void Update()
    {
        // Determine the current speed based on whether the player is sprinting or not
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }

        // Input from the horizontal (A/D or left/right arrow keys) and vertical (W/S or up/down arrow keys) axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the direction the player should move based on input
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // If the input has a direction (not 0,0), move the player
        if (moveDirection.magnitude >= 0.1f)
        {
            // Calculate the movement relative to the camera's orientation
            moveDirection = Camera.main.transform.TransformDirection(moveDirection);
            moveDirection.y = 0f; // Ensure the player does not move up or down

            // Move the player
            transform.Translate(moveDirection * currentSpeed * Time.deltaTime, Space.World);
        }
    }
}
