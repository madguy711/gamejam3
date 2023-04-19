using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float smoothing = 5f; // How smoothly the camera should follow the player

    //private Vector3 offset; // The initial offset between the camera and the player

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        // Only move the camera along the x-axis
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);

        // Use Lerp to smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}