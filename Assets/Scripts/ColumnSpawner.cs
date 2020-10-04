using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawner : MonoBehaviour
{
    public float maxTime;
    float Timer;
    float randY;
    public float minY;
    public float maxY;
    public GameObject myColumn;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gamePaused == false)
        {
            Timer += Time.deltaTime;
        }
        if (Timer >= maxTime && GameManager.gameOver == false && GameManager.gameStarted == true && GameManager.gamePaused == false)
        {
            
            SpawnColumn();
            Timer = 0;
        }
    }

    void SpawnColumn()
    {
        randY = Random.Range(minY , maxY);
        GameObject newColumn = Instantiate(myColumn);
        newColumn.transform.position = new Vector2(transform.position.x, randY);
    }
}
