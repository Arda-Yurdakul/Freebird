using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator BlackFadeAnim;

    public void onPlayButtonPressed()
    {
        BlackFadeAnim.SetTrigger("fadeIn");
        AudioManager.audiomanager.Play("transition");
    }

    public void onRateButtonPressed()
    {
#if UNITY_ANDROID
        Application.OpenURL("market://details?id=com.EArdaGames.Freebird");
#endif 	
    }

}
