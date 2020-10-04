using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameOver : MonoBehaviour
{
    public Score score;
    public GameObject medal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameOverBehavior()
    {
        score.DrawScore();
        medal.SetActive(true);
        
    }

    public void LoseSound()
    {
        AudioManager.audiomanager.Play("die");
    }
}
