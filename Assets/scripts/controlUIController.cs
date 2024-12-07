using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class controlUIController : MonoBehaviour
{
    private Button button;
    public GameObject otherUI;
    public GameObject controlUI;
    public GameObject buttonText;
    private bool isTitle = true;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(click);
    }

    // Update is called once per frame
    void click()
    {
        if (isTitle)
        {
            isTitle = false;
            otherUI.SetActive(false);
            controlUI.SetActive(true);
            buttonText.GetComponent<TextMeshProUGUI>().SetText("Go Back");
        }
        else
        {
            isTitle = true;
            otherUI.SetActive(true);
            controlUI.SetActive(false);
            buttonText.GetComponent<TextMeshProUGUI>().SetText("Controls");
        }
    }
}
