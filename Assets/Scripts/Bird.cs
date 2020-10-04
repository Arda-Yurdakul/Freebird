using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour

{
    public Ground ground;
    public GameManager gameManager;
    public Score score;
    public float speed;
    private bool alreadyhit = false;
    Rigidbody2D rb;
    float angle;
    float maxAngle = 20;
    float minAngle = -90;
    public Sprite deadBird;
    SpriteRenderer sp;
    Animator an;

    IEnumerator ExecuteAfterTime(float time, Rigidbody2D rb)
    {
        yield return new WaitForSeconds(time);

        rb.gravityScale = 0.75f;
    }




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        //StartCoroutine(ExecuteAfterTime(0.25f , rb));
        sp = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false && GameManager.gamePaused == false)
        {
            if (GameManager.gameStarted == true)
            {
                AudioManager.audiomanager.Play("flap");
                rb.velocity = Vector2.zero;
                rb.velocity = new Vector2(rb.velocity.x, speed);
        }
            else
            {
                gameManager.StartGame();
            }

            
        }

        else if (GameManager.gamePaused == true)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<Animator>().enabled = false;

        }

        BirdRotate();

    }


    void BirdRotate()
    {
        if (rb.velocity.y > 0)
        {
            if (angle < maxAngle)
            {
                angle = angle + 1;
            }
        }

        else if (rb.velocity.y < -0.8f)
        {
            if (angle > minAngle)
            {
                angle = angle - 0.5f;
            }
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Column"))
        {
            score.IncreaseScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            gameManager.EndGame();
            deathState();
        }
        else if (collision.gameObject.CompareTag("Column"))
        {
            foreach (BoxCollider2D c in collision.gameObject.GetComponents<BoxCollider2D>())
            {
                c.enabled = false;
            }
            gameManager.EndGame();
            deathState();
        }
    }

    void deathState()
    {
        if(!alreadyhit)
        {
            alreadyhit = true;
            AudioManager.audiomanager.Play("hit");
        }
        an.enabled = false;
        sp.sprite = deadBird;
        transform.rotation = Quaternion.Euler(0, 0, minAngle);
        
    }
}
