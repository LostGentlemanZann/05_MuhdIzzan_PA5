using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    //public Animator animator;
    public GameObject scoreText;
    public int score;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Solid")) 
        {
            rb.velocity = Vector3.zero;
            print("WallTouch");
        }

        if (collision.gameObject.tag == ("Hazard")) 
        {
            Destroy(gameObject);
            SceneManager.LoadScene(2);
        }

        if (collision.gameObject.tag == "Gem")
        {
            score += 1;
            scoreText.GetComponent<Text>().text = "Score : " + score;
            Destroy(collision.gameObject);
        }
    }

    [Tooltip("Speed of the player")]
    public float MovementSpeed;

    private Rigidbody rb = null;
    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();

    }
    // Update is called once per frame
    void Update()
    {
        
        UpdateMovement();
        UpdateRotation();

        if (score == 4) 
        {
            SceneManager.LoadScene(1);
        }

        /*if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) 
        {
            animator.SetBool("IsWalking", true);
        }
        else if (!Input.anyKey)
        {
            animator.SetBool("IsWalking", false);
        }*/
    }
    private void UpdateMovement()
    {
        // Get the direction based on the user input
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveDirection.Normalize();

        // Set the velocity to the direction * movement speed
        rb.velocity = new Vector3(moveDirection.x * MovementSpeed,
                                  rb.velocity.y,
                                  moveDirection.z * MovementSpeed);
           }

    private void UpdateRotation()
    {
        // The step size is dependent on the delta time.
        float step = MovementSpeed * 3 * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, moveDirection, step, 0.0f);

        // Rotate our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
