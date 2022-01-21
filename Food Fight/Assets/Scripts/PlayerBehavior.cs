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

    // Start is called before the first frame update
    void Start()
    {
        this.gameBehavior = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
        this.playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        // This if block is just for testing purposes
        if (Input.GetMouseButtonDown(0))
        {
            GainPoint();
        }
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
