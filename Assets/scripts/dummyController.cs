using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class dummyController : MonoBehaviour
{
    [Header("Player States")]
    public bool shield = false;
    public bool attack = false;
    public bool throwing = false;
    [Header("Game Objects")]
    public GameObject p1;
    public GameObject weapon;
    public GameObject projectile;
    public tutorialController tutorialController;
    [Header("Rigidbody")]
    public Rigidbody rb;
    [Header("Particles")]
    public ParticleSystem clashParticle;
    //numbers
    private float timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shield){
            weapon.SetActive(true);
        }
        if (throwing)
        {
            if (timer <= 0f)
            {
                projectile.GetComponent<projectileController>().Throw();
                timer = 3;
            }
            timer -= Time.deltaTime;
        }
        if (attack)
        {
            if (timer <= 0f)
            {
                weapon.GetComponent<attack1>().whack();
                timer = 3;
            }
            timer -= Time.deltaTime;
        }
        if (p1.transform.position.x > gameObject.transform.position.x)
        {
            weapon.GetComponent<attack1>().direction = 1;
        }
        else
        {
            weapon.GetComponent<attack1>().direction = -1;
        }
        if (transform.position.y < -2)
        {
                tutorialController.Restart();
                gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "projectile" && !shield)
        {
            rb.AddForce((transform.position.x - collision.transform.position.x) * 2.5f, (transform.position.y - collision.transform.position.y) * 3, 0, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hurt1" && shield == false && p1.GetComponent<playerControllerP1>().shield == false)
        {
            tutorialController.Restart();
            gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "hurt1" && shield == true && p1.GetComponent<playerControllerP1>().shield == false)
        {
            clashParticle.Play();
            rb.AddForce(2.5f * weapon.GetComponent<attack1>().direction * -1, 2, 0, ForceMode.Impulse);
        }
    }
    public void idle()
    {
        timer = 2f;
        weapon.SetActive(false);
        attack = false;
        throwing = false;
        shield = false;
    }

}
