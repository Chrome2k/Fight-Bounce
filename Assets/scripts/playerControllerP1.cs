using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Search;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class playerControllerP1 : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject player2;
    public GameObject weapon;
    public GameObject projectile;
    public GameObject GameController;
    [Header("Floats")]
    public float playerSpeed = 1;
    public float jumpPower = 0.5f;
    private float horizontal = 0;
    private float timer = -8f;
    [Header("Rigidbody")]
    public Rigidbody rb;
    [Header("Bools")]
    public bool isGrounded = true;
    private bool bigJump;
    public bool sheild = false;
    [Header("Particles")]
    public ParticleSystem clashParticle;
    //vectors
    private Vector3 jump;
    private Vector3 jump2 = new Vector3(1, 2, 0);

    // Start is called before the first frame update
    void Start()
    {
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("HorizontalP1") * playerSpeed * Time.deltaTime;
        transform.Translate(Vector3.right * horizontal);
        if (Input.GetKeyDown("e") && sheild != true)
        {
            weapon.GetComponent<attack1>().whack();
        }
        if (Input.GetKeyDown("s"))
        {
            sheild = true;
            playerSpeed = 2f;
        }
        if (Input.GetKeyUp("s"))
        {
            sheild = false;
            sheild = false;
            weapon.SetActive(false);
            playerSpeed = 6f;
        }
        if (Input.GetKeyDown("w") && isGrounded == true)
        {
            timer = 0f;
            bigJump = true;
            rb.AddForce(jump * jumpPower, ForceMode.Impulse);
        }
        else if (bigJump == true && Input.GetKey("w"))
        {
            timer += Time.deltaTime;
            if (timer > 0.15f)
            {
                bigJump = false;
                jump2.x *= horizontal;
                rb.AddForce(jump2 * 2, ForceMode.Impulse);
            }
        }
        else if (isGrounded == false)
        {
            bigJump = false;
        }
        if (sheild == true)
        {
            weapon.SetActive(true);
        }
        if(player2.transform.position.x > gameObject.transform.position.x)
        {
            weapon.GetComponent<attack1>().direction = 1;
        }
        else
        {
            weapon.GetComponent<attack1>().direction = -1;
        }
        if (Input.GetKeyDown("q") && !sheild)
        {
            projectile.GetComponent<projectileController>().Throw();
        }
        if (transform.position.y < -2)
        {
            GameController.GetComponent<gameController>().Restart();
            gameObject.SetActive(false);
            GameController.GetComponent<gameController>().score2Plus();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "projectile" && !sheild)
        {
            rb.AddForce((transform.position.x - collision.transform.position.x) * 2.5f, (transform.position.y - collision.transform.position.y)*3, 0, ForceMode.Impulse);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(isGrounded == true && collision.gameObject.tag == "floor")
        {
            isGrounded = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "hurt2" && sheild == false && player2.GetComponent<playerControllerP2>().sheild == false)
      {
            gameObject.SetActive(false);
            GameController.GetComponent<gameController>().score2Plus();
            GameController.GetComponent<gameController>().Restart();
        }
      else if (other.gameObject.tag == "hurt2" && sheild == true && player2.GetComponent<playerControllerP2>().sheild == false)
      {
            clashParticle.Play();
            rb.AddForce(2.5f * weapon.GetComponent<attack1>().direction * -1, 2, 0, ForceMode.Impulse);
      }
    }
}