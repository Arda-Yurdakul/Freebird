using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparkle1 : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(panel.transform.position.y != 0)
        {
            print(panel.transform.position.y);
            gameObject.SetActive(true);
        }
    }
}
