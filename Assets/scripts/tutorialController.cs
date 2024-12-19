using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class tutorialController : MonoBehaviour
{
    public int num = 0;
    public TextMeshProUGUI helpText;
    public dummyController dummyController;
    public void Restart()
    {
        Invoke("Load", 2);
    }
    private void Load()
    {
        SceneManager.LoadScene(3);
    }
    public void butttons()
    {
        dummyController.idle();
        if (num == 1)
        {
            dummyController.attack = true;
            helpText.text = "Defend against the other players attacks by pressing [S]! Even though you take knockback, it's better than dieing!";
        }
        if (num == 2)
        {
            dummyController.throwing = true;
            helpText.text = "You can also defend against the projectile by pressing [S]! However it only reduces the knockback...";
        }
        if (num == 3)
        {
            dummyController.shield = true;
            helpText.text = "Attack the opponent and win by throwing them off the edge!";
        }
    }
}
