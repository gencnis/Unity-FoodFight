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
    public float jumpVelocity = 5f;
    private float vInput;
    private float hInput;
    //The Rigidbody object we will use
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        this.gameBehavior = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
        this.playerTransform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // This if block is just for testing purposes
        if (Input.GetMouseButtonDown(0))
        {
            GainPoint();
        }
        if (Input.GetKeyDown(KeyCode.Space))
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
    /// When the user eats a snickers bar, scale their size by 1 and add a point to the game manager
    /// </summary>
    private void GainPoint()
    {
        playerTransform.localScale = playerTransform.localScale + Vector3.one;
        gameBehavior.SnickersCollected = gameBehavior.SnickersCollected + 1;    
    }
}
