using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class projectileController : MonoBehaviour
{
    public GameObject sword;
    public GameObject player;
    public Rigidbody rb;
    private bool isUsed = false;
    private bool isReturning = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        if (transform.position.y <= -1 && !isReturning)
        {
            isReturning = true;
            Invoke("Return", 1f);
        }
    }
    void Return()
    {
        gameObject.SetActive(false);
        isUsed = false;
        isReturning = false;
    }
    public void Throw()
    {
        if (isUsed == false)
        {
            gameObject.transform.position = player.transform.position + new Vector3(1 * sword.GetComponent<attack1>().direction, 0, 0);
            gameObject.SetActive(true);
            isUsed = true;
            rb.velocity = Vector3.zero;
            rb.AddForce(8 * sword.GetComponent<attack1>().direction, 4, 0, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "floor" && !isReturning)
        {
            isReturning = true;
            Invoke("Return", 1f);
        }
    }
}
