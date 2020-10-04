using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;
    int highScore;
    int drawScore;
    public Text scorePanelText;
    public Text highScorePanelText;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        drawScore = 0;
        highScore = PlayerPrefs.GetInt("highScore");
        scorePanelText.text = score.ToString();
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        highScorePanelText.text = highScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        //scorePanelText.text = score.ToString();
        if (score > highScore)
        {
            highScore = score;
            highScorePanelText.text = highScore.ToString();
            PlayerPrefs.SetInt("highScore", highScore);
            GameManager.newRecord = true;
        }
        AudioManager.audiomanager.Play("point");

    }

    public int GetScore()
    {
        return score;
    }

    public void DrawScore()
    {
        if(drawScore <= score)
        {
            scorePanelText.text = drawScore.ToString();
            drawScore++;
            Invoke("DrawScore", 0.05f);
        }
    }
}
