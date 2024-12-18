using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummyController : MonoBehaviour
{
    [Header("Player States")]
    public bool shield = false;
    public bool attack = false;
    public bool throwing = false;
    public bool idle = true;
    [Header("Game Objects")]
    public GameObject p1;
    public GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shield){

        }
        if (attack)
        {

        }
        if (throwing)
        {

        }
        if (idle)
        {

        }
    }
}
