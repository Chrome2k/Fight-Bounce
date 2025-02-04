using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour
{
    private float timer = 0;
    private const float minX = -8.45f;
    private const float maxX = 8.45f;
    private const float minY = 2.88f;
    private const float maxY = 7.5f;
    private float directionX = 0;
    private float directionY = 0;
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
        if (transform.localPosition.x < minX || transform.localPosition.x > maxX || transform.localPosition.y < minY || transform.localPosition.y > maxY)
        {
            directionX *= -1;
            directionY *= -1;
        }
        timer += Time.deltaTime;
        if(timer >= 3)
        {
            var newPlat = Instantiate(gameObject, new Vector3(Random.Range(4,8), 3, gameObject.transform.position.z), gameObject.transform.rotation);
            newPlat.transform.parent = empty.transform;
            timer = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
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
        if(directionX == 0 || directionY == 0)
        {
            changeDirection();
        }
    }
}
