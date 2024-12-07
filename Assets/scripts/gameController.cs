using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class gameController : MonoBehaviour
{
    private bool isRestarting = false;
    public static int score1 = 0;
    public static int score2 = 0;
    private float timer = 45;
    [Header("Paricle Systems")]
    public ParticleSystem deathParticleP1;
    public ParticleSystem deathParticleP2;
    [Header("Game Objects")]
    public GameObject p1;
    public GameObject p2;
    [Header("Text")]
    public TMP_Text score1text;
    public TMP_Text score2text;
    public TMP_Text timerText;

    private void Start()
    {
        isRestarting = false;
        score1text.text = "Score 1: " + score1;
        score2text.text = "Score 2: " + score2;
    }
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = "Timer: " + Mathf.Round(timer);
        }
        else if(!isRestarting)
        {
            score1++;
            score2++;
            if(score1 == 10 || score2 == 10)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }
    }
    public void score1Plus()
    {
        deathParticleP2.gameObject.transform.position = p2.transform.position;
        deathParticleP2.Play();
        if (!isRestarting)
        {
            isRestarting = true;
            score1++;
            score1text.text = "Score 1: " + score1;
        }
        if(score1 >= 10)
        {
            SceneManager.LoadScene("gameOver");
        }
    }
    public void score2Plus()
    {
        deathParticleP1.gameObject.transform.position = p1.transform.position;
        deathParticleP1.gameObject.SetActive(true);
        deathParticleP1.Play();
        if (!isRestarting)
        {
            isRestarting = true;
            score2++;
            score2text.text = "Score 2: " + score2;
        }
        if (score2 >= 10)
        {
            SceneManager.LoadScene("gameOver");
        }
    }
    public void Restart()
    {
        Invoke("Load", 2);
    }
    private void Load()
    {
        SceneManager.LoadScene(1);
    }
}
