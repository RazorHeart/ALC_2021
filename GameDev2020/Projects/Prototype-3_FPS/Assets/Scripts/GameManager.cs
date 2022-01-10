using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;
    public int curScore;

    public bool gamePaused;
    public static GameManager instance;

    void Awake()
    {
        //setting the instance
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Cancel"))
        {
            TogglePauseGame();
        }
    }
    public void TogglePauseGame()
    {
        //freeze game
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        //toggle pause
        GameUI.instance.TogglePauseMenu(gamePaused);

        //Toggle mouse
        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void AddScore(int score)
    {
        curScore += score;

        //update text
        GameUI.instance.UpdateScoreText(curScore);

        //are we there yet?
        if(curScore >= scoreToWin)
            WinGame();
    }

    public void WinGame()
    {
        //end screen
        GameUI.instance.GetEndGameScreen(true, curScore);

    }

    public void LoseGame()
    {
        //end screen
        GameUI.instance.GetEndGameScreen(false, curScore);
        Time.timeScale = 0.0f;
        gamePaused = true;
    }

}
