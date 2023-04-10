using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseForceTest : MonoBehaviour
{
    // Start is called before the first frame update

    public float forceMultiplier = 25f; // the force applied to the player

    private Rigidbody2D rb;

    private bool isGrounded; // if player is touching the ground

    private float shotsFired; // track the number of shots fired

    private float lastShotTime; // for the reload time 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // check if left mouse button is clicked
        {
            if ((isGrounded && (shotsFired <= 1)) && (Time.time - lastShotTime > 1f)) // check if the player is touching the ground and hasn't fired more than two shots, wait one second before being able to fire after hitting ground
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get the mouse position in world space
                Vector2 direction = (mousePosition - transform.position).normalized; // get the direction of the click
                direction.Normalize();

                rb.AddForce(-direction * forceMultiplier, ForceMode2D.Impulse); // apply the impulse force in the opposite direction of the click
                shotsFired++;
                FindObjectOfType<AudioManager>().Play("ShotgunShot");
            }
        }

        if ((Input.GetKey(KeyCode.R)) && shotsFired != 0) // If the player presses R then they will reload
        {
            Reload();
        }
    }

    void FixedUpdate()
    {
        // apply the equations for 2D directional kinematic motion
        Vector2 velocity = rb.velocity;
        float vx = velocity.x;
        float vy = velocity.y;

        float time = Time.fixedDeltaTime; // get the time since the last fixed update
        float gravity = Physics2D.gravity.y;

        vx = vx; // horizontal velocity remains constant
        vy = vy + gravity * time; // vertical velocity changes due to gravity

        rb.velocity = new Vector2(vx, vy);
    }

    private void OnCollisionEnter2D(Collision2D collision) // method for when the player touches the floor
    {
        if ((collision.gameObject.CompareTag("Floor")) && (shotsFired >= 2))
        {
            isGrounded = true;
            rb.velocity = Vector2.zero; // reset velocity when landing on floor
            shotsFired = 0f; // reset shots back to zero 
            lastShotTime = Time.time; // make the player wait before shooting again
        }

        else // If player only fires one shot then lands then they instantly fire another before having to reload 
        {
            isGrounded = true;
            rb.velocity = Vector2.zero; // reset velocity when landing on floor
        }
    }

    private void Reload() // This method will just set shots fired to 0 and have a 1 second wait
    {
        shotsFired = 0f; // reset shots back to zero 
        lastShotTime = Time.time; // make the player wait before shooting again
    }
}
