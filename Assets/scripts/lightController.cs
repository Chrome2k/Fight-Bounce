using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class lightController : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public SphereCollider innerSphereCollider;
    public SphereCollider outerSphereCollider;

    private const float lightRadiusRatio = 5.57f;
    private const float lightRadiusOffset = 4.5f;
    private const float sphereColliderDifference = 0.5f;

    private Light spotLight;

    // Start is called before the first frame update
    void Start()
    {
        //outerSphereCollider.GetComponent<sphereCollidersController>().isColliding = false;
        spotLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!outerSphereCollider.GetComponent<sphereCollidersController>().isColliding)
        {
            outerSphereCollider.radius += 0.01f;
        }
        if(innerSphereCollider.GetComponent<sphereCollidersController>().isColliding && outerSphereCollider.radius > 0.01f)
        {
            outerSphereCollider.radius -= 0.01f;
        }
        innerSphereCollider.radius = outerSphereCollider.radius - sphereColliderDifference;
        spotLight.spotAngle = outerSphereCollider.radius * lightRadiusRatio + lightRadiusOffset;
    }
}
