using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main script to define how the player behaves
/// </summary>
public class PlayerBehavior : MonoBehaviour
{
    public GameBehavior gameBehavior;
    public Transform playerTransform;


    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float jumpVelocity = 10f;
    private float vInput;
    private float hInput;


    // Variable for distance to ground
    public float distanceToGround = 0.1f;
    // Layermask variable that we can use from inspector
    public LayerMask groundLayer;
    // Variable for player's collider component
    private CapsuleCollider _col;


    //The Rigidbody object we will use
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        this.gameBehavior = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
        this.playerTransform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();

        // Get Player's capsule collider info
        _col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        // This if block is just for testing purposes
        if (Input.GetMouseButtonDown(0))
        {
            GainPoint();
        }
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            // 3
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }

        //Vertical input
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        //Horizontal input
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
    }
    void FixedUpdate()
    {
        //Vector for rotation
        Vector3 rotation = Vector3.up * hInput;
        //Getting the angle for rotation
        Quaternion angleRot = Quaternion.Euler(rotation *
       Time.fixedDeltaTime);
        //Use the Rigitbody method for traversal
        _rb.MovePosition(this.transform.position +
       this.transform.forward * vInput * Time.fixedDeltaTime);
        // Use the Rigitbody method for rotation
        _rb.MoveRotation(_rb.rotation * angleRot);
    }

    /// <summary>
	/// This bool checks if you're close enough to the ground to jump again.
	/// </summary>
    private bool IsGrounded()
    {
        // Data for the bottom of the player
        Vector3 capsuleBottom = new
        Vector3(_col.bounds.center.x, _col.bounds.min.y,
        _col.bounds.center.z);
        // Checks if the bottom is on the ground
        bool grounded =
        Physics.CheckCapsule(_col.bounds.center, capsuleBottom,
        distanceToGround, groundLayer,
        QueryTriggerInteraction.Ignore);
        // Return the bool (True or False
        return grounded;
    }

    /// <summary>
    /// When the user eats a snickers bar, scale their size by 1 and add a point to the game manager
    /// </summary>
    private void GainPoint()
    {
        playerTransform.localScale = playerTransform.localScale + Vector3.one;
        gameBehavior.SnickersCollected = gameBehavior.SnickersCollected + 1;    
    }

    // On collision store info of collision
    void OnCollisionEnter(Collision collision)
    {
        // If it is the player execute code
        if (collision.gameObject.name == "Watermelon")
        {
            GainPoint();
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
    }
}
