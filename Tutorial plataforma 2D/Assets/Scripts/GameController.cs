using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text ScoreText;
    public GameObject gameOver;
    
    public static GameController instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void updateScoreText()
    {
        ScoreText.text = totalScore.ToString();
    }

    public void showGameOver()
    {
        gameOver.SetActive(true);
    }

    public void restartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

}
