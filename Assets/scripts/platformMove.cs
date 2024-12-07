using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour
{
    private const float minX = -8.45f;
    private const float maxX = 8.45f;
    private const float minY = 2.88f;
    private const float maxY = 7.5f;
    private float directionX = 0;
    private float directionY = 0;
    private bool outOfBounds = false;
    public GameObject empty;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(options.isPlatformOn);
        changeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * directionX);
        transform.Translate(Vector3.up * directionY);
        if (transform.localPosition.x < minX || transform.localPosition.x > maxX || transform.localPosition.y < minY || transform.localPosition.y > maxY && !outOfBounds)
        {
            outOfBounds = true;
            directionX *= -1;
            directionY *= -1;
        }
        else
        {
            outOfBounds = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            var newPlat = Instantiate(gameObject, new Vector3(gameObject.transform.position.x + Random.Range(-2, 2), gameObject.transform.position.y + Random.Range(1,3), gameObject.transform.position.z), gameObject.transform.rotation);
            newPlat.transform.parent = empty.transform;
        }
        changeDirection();
    }
    private void OnTriggerEnter(Collider other)
    {
        changeDirection();
    }
    private void changeDirection() 
    {
        directionX = Random.Range(-2, 2) * Time.deltaTime;
        directionY = Random.Range(-2, 2) * Time.deltaTime;
    }
}
