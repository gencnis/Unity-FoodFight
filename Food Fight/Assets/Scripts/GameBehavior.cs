using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Defines how the game will work
/// </summary>
public class GameBehavior : MonoBehaviour
{
    public int maxNumSnickers = 5;
    public bool showWinScreen = false;
   public string labelText = "Devour 5 watermelons and win your freedom! Remember: the walls haunt you, but don't trust them!";
    private int _snickersCollected;
    bool showGUI = false;
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
                labelText = "You've eaten them all!";
                showWinScreen = true;
                Debug.Log("Congratulations! You have eaten all the snickers bars.");
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Watermelon down, only " + (maxNumSnickers - _snickersCollected) + " more to go!";
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


    void OnEnable()
    {
        showGUI = true;
    }
    void OnDisable()
    {
        showGUI = false;
    }

    //Update the GUI with the current state of the game
    void OnGUI()
    {
        if (showGUI)
        {
            GUI.Box(new Rect(20, 50, 200, 30), "Watermelons harvested: " + _snickersCollected);
            // 6
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);
            if (showWinScreen)
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 100,
               Screen.height / 2 - 50, 200, 100), "YOU WON!"))
                {
                    // 3
                    SceneManager.LoadScene(0);
                    // 4
                    Time.timeScale = 1.0f;
                }
            }
        }
    }
}
