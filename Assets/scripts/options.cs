using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class options : MonoBehaviour
{
    public UnityEngine.UI.Toggle toggle;
    public static bool isPlatformOn = false;
    // Start is called before the first frame update
    void Start()
    {
        gameController.score1 = 0;
        gameController.score2 = 0;
    }
    private void Update()
    {
        if (toggle.isOn)
        {
            isPlatformOn = true;
        }
        else
        {
            isPlatformOn = false;
        }
    }

}
