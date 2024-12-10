using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonController : MonoBehaviour
{
    public int nextStage = 1;
    private Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(click);
    }
    private void click()
    {
            SceneManager.LoadScene(nextStage);
    }
}
