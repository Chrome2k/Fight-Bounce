using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tutorialButtons : MonoBehaviour
{
    public int buttonNum = 1;
    private Button button;
    public tutorialController controller;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(click);
    }

    private void click()
    {
        controller.num = buttonNum;
        controller.butttons();
    }
}
