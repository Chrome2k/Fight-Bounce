using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    private static bool musicPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (musicPlaying == false)
        {
            musicPlaying = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
