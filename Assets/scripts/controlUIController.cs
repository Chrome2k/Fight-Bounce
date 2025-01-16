using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class controlUIController : MonoBehaviour
{
    private Button button;
    public GameObject otherUI;
    public GameObject otherUI2;
    public GameObject onUI;
    public GameObject buttonText;
    public string originalText = "";
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
            otherUI2.SetActive(false);
            onUI.SetActive(true);
            buttonText.GetComponent<TextMeshProUGUI>().SetText("Go Back");
        }
        else
        {
            isTitle = true;
            otherUI.SetActive(true);
            //otherUI2.SetActive(true);
            onUI.SetActive(false);
            buttonText.GetComponent<TextMeshProUGUI>().SetText(originalText);
        }
    }
}
