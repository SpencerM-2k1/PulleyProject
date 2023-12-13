using UnityEngine;

public class ObjectTransport : MonoBehaviour
{
    public Transform targetPosition; // The position where you want to move the object
    public float speed = 5.0f; // The speed at which the object moves

    private bool isMoving = false; // Flag to check if the object is currently moving

    void Update()
    {
        // Check for user input or trigger condition to start moving the object
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            // Call a method to start moving the object
            StartMovingObject();
        }

        // Move the object if it is currently moving
        if (isMoving)
        {
            // Calculate the step size based on the speed and frame rate
            float step = speed * Time.deltaTime;

            // Move the object towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, step);

            // Check if the object has reached the target position
            if (transform.position == targetPosition.position)
            {
                isMoving = false; // Stop moving when the target position is reached
            }
        }
    }

    void StartMovingObject()
    {
        isMoving = true;
    }
}
