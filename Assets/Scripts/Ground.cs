using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float speed;
    BoxCollider2D box;
    float groundWidth;
    
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Ground"))
        {
            box = GetComponent<BoxCollider2D>();
            groundWidth = box.size.x;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameManager.gameOver == false && GameManager.gameStarted == true && GameManager.gamePaused == false) 
        {
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            if (transform.position.x <= -groundWidth)
            {
                if (gameObject.CompareTag("Ground"))
                {
                    transform.position = new Vector2(groundWidth - 0.005f, transform.position.y);
                }

                else if (gameObject.CompareTag("Column"))
                {
                    if (transform.position.x <= GameManager.bottomLeft.x - 1)
                    {
                        Destroy(gameObject);
                    }
                }

            }
        }
        
    }
}
