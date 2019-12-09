using UnityEngine;
using UnityEngine.UI;
using System;

public class score : MonoBehaviour
{
    public Text scoreText;
    bool gameOver = false;
    // Update is called once per frame
    public void Update()
    {
        if (gameOver == false)
        {
            scoreText.text = ((1 * 1.3) + Int32.Parse(scoreText.text)).ToString("0");
            //scoreText.text = ((Time.time / 3) + Int32.Parse(scoreText.text)).ToString("0");
        }
    }

}
