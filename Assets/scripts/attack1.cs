using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class attack1 : MonoBehaviour
{
    public int direction = 1;
    private Vector3 leftPos = new Vector3(-0.436f, -0.312f, 0.337f);
    private Vector3 rightPos = new Vector3(0.436f, -0.312f, 0.337f);
    private bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
        Restart();
    }
    private void Update()
    {
        if (direction == 1)
        {
            transform.localPosition = rightPos;
            gameObject.transform.localRotation = Quaternion.Euler(transform.eulerAngles.x, 0, transform.eulerAngles.z);
        }
        else
        {
            transform.localPosition = leftPos;
            gameObject.transform.localRotation = Quaternion.Euler(transform.eulerAngles.x, 180, transform.eulerAngles.z);
        }
    }
    public void Restart()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.SetActive(false);
        isAttacking = false;
    }
    public  void whack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            gameObject.SetActive(true);
            StartCoroutine(waiter());
            Invoke("Restart", 0.35f);
        }
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.1f);
        transform.Rotate(0, 0 ,-30 );
        yield return new WaitForSeconds (0.1f);
        transform.Rotate(0, 0 ,-30 );
        yield return new WaitForSeconds(0.1f);
        transform.Rotate(0, 0, -30 );
    }
}
