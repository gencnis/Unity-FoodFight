using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines how the game will work
/// </summary>
public class GameBehavior : MonoBehaviour
{
    public int maxNumSnickers = 5;
    public bool showWinScreen = false;

    private int _snickersCollected;

    public WallScript wall;


    /// <summary>
    /// Access variable for the number of snickers bar the player has collected
    /// </summary>
    public int SnickersCollected
    {
        get { return _snickersCollected; }
        set
        {
            _snickersCollected = value;
            Debug.LogFormat("You've eaten {0} snickers bars!", _snickersCollected);

            // If the user has collected all the snickers, the game is won
            if(_snickersCollected >= maxNumSnickers)
            {
                showWinScreen = true;
                Debug.Log("Congratulations! You have eaten all the snickers bars.");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        wall = GameObject.Find("DreadedWallOff").GetComponent<WallScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Whenever a player collects a snack, this method is called
    public void PointCollected()
    {
        wall.HauntThePlayer();
    }
}
