using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public static bool newRecord;
    public float speed;
    public Animator BlackFadeAnim;
    public Animator HitStun;
    public Animator CameraShake;
    public Animator MenuSlide;
    public GameObject BirdParent;
    public GameObject PauseButton;
    public GameObject ResumeButton;
    public GameObject Bird;
    public GameObject ScoreText;
    public GameObject NewHighScoreText;
    public GameObject GetReadyImage;
    public GameObject GameOverCanvas;
    public static Vector2 bottomLeft;

    //game states
    public static bool gameOver;
    public static bool gameStarted;
    public static bool gamePaused;


    // Start is called before the first frame update

    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));    
    }

    void Start()
    {
        gameOver = false;
        gameStarted = false;
        gamePaused = false;
        ScoreText.SetActive(false);
        PauseButton.SetActive(false);
        newRecord = false;
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame()
    {
        gameStarted = true;
        ScoreText.SetActive(true);
        GetReadyImage.SetActive(false);
        PauseButton.SetActive(true);
        rb = Bird.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.velocity = new Vector2(rb.velocity.x, speed);
        rb.gravityScale = 0.75f;
        anim = BirdParent.GetComponent<Animator>();
        anim.enabled = false;


    }

    public void PauseGame()
    {
        gamePaused = true;
        ResumeButton.SetActive(true);
    }

    public void ResumeGame()
    {
        gamePaused = false;
        ResumeButton.SetActive(false);
        Bird.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Bird.GetComponent<Animator>().enabled = true;
    }

    public void EndGame()
    {
        gameOver = true;
        HitStun.SetTrigger("BirdDead");
        CameraShake.SetTrigger("BirdIsDead");
        GameOverCanvas.SetActive(true);
        MenuSlide.SetTrigger("GameOver");
       
        ScoreText.SetActive(false);
        PauseButton.SetActive(false);
        NewHighScoreText.SetActive(newRecord);

    }

    public void OnOKButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioManager.audiomanager.Play("transition");
    }

    public void OnMenuButtonPressed()
    {
        SceneManager.LoadScene("MenuScene");
        BlackFadeAnim.SetTrigger("fadeIn");
        AudioManager.audiomanager.Play("transition");
    }
}
