using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
    using UnityEditorInternal;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackFade : MonoBehaviour
{
    public void OnBlackFadeFinished()
    {
        if(SceneManager.GetActiveScene().name =="PlayScene")
        {
            SceneManager.LoadScene("MenuScene");
        }
        else if (SceneManager.GetActiveScene().name == "MenuScene")
        {
            SceneManager.LoadScene("PlayScene");
        }
    }
}
