using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereCollidersController : MonoBehaviour
{
    public bool isColliding = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isColliding = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isColliding = false;
        }
    }
}
