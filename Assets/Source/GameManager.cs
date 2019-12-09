using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public bool gameover = false;

    void Start()
    {
        if (FindObjectOfType<HighScore>().GetComponent<Text>().text.Equals(""))
        {
            PlayerPrefs.SetString("HighScore", "0");
        }

        FindObjectOfType<HighScore>().GetComponent<Text>().text = PlayerPrefs.GetString("HighScore");
    }

    public void GameOver()
    {
        gameover = true;
        //FindObjectOfType<GameOver>().GetComponent<Text>().text = "Game Over";
        FindObjectOfType<ScoreAchieved>().GetComponent<Text>().text = FindObjectOfType<score>().scoreText.text;

        if (FindObjectOfType<HighScore>().GetComponent<Text>().text.Equals(""))
        {
            //Debug.Log("no high score");
            PlayerPrefs.SetString("HighScore", FindObjectOfType<ScoreAchieved>().GetComponent<Text>().text);
            FindObjectOfType<HighScore>().GetComponent<Text>().text = PlayerPrefs.GetString("HighScore");
        }

        if (Int32.Parse(FindObjectOfType<ScoreAchieved>().GetComponent<Text>().text) > Int32.Parse(FindObjectOfType<HighScore>().GetComponent<Text>().text))
        {
            //Debug.Log("NEW high score");
            PlayerPrefs.SetString("HighScore", FindObjectOfType<ScoreAchieved>().GetComponent<Text>().text);
            FindObjectOfType<HighScore>().GetComponent<Text>().text = PlayerPrefs.GetString("HighScore");
        }

        //Debug.Log("Score achieved: " + Int32.Parse(FindObjectOfType<ScoreAchieved>().GetComponent<Text>().text));
        //Debug.Log("High score: " + FindObjectOfType<HighScore>().GetComponent<Text>().text);

        FindObjectOfType<GameOverTitle>().GetComponent<Text>().enabled = true;
        FindObjectOfType<ScoreAchieved>().GetComponent<Text>().enabled = true;
        StopScore();
        StopMovement();

    }

    public void StopScore()
    {
        FindObjectOfType<score>().enabled = false;
        FindObjectOfType<score>().scoreText.text = ":(";
    }

    public void StopMovement()
    {
        //Debug.Log("Stop Movement");
        FindObjectOfType<obstacleMovement>().GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        FindObjectOfType<playerCollision>().GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        if (Input.GetKeyUp("space") && gameover)
        {
            RestartGame();
        }

        if (Input.GetKey("left shift") && Input.GetKey("r"))
        {
            PlayerPrefs.DeleteAll();
            Invoke("RestartGame", 1);
        }
    }
}
