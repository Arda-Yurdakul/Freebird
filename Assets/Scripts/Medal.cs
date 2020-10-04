using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    public Score score;
    public Sprite normalMedal;
    public Sprite bronzeMedal;
    public Sprite silverMedal;
    public Sprite goldMedal;

    private int currentScore;

    Image medalImage;

    // Start is called before the first frame update
    void Start()
    {
        medalImage = GetComponent<Image>();
        currentScore = score.GetScore();
        if(currentScore >= 0 && currentScore < 4)
            medalImage.sprite = normalMedal;
        else if (currentScore >= 4 && currentScore < 10)
            medalImage.sprite = bronzeMedal;
        else if (currentScore >= 10 && currentScore < 20)
            medalImage.sprite = silverMedal;
        else if (currentScore >= 20)
            medalImage.sprite = goldMedal;
    }

   
}
