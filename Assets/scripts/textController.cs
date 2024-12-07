using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textController : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        int score1 = gameController.score1;
        int score2 = gameController.score2;
        if (score1 > score2)
        {
            text.text = "PLAYER 1 WINS!";
        }
        else if ((score2 > score1))
        {
            text.text = "PLAYER 2 WINS!";
        }
        else
        {
            text.text = "TIE!";
        }
        gameController.score1 = 0;
        gameController.score2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
