using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    Transform planet;
    Rigidbody rb;

    float gravity = -9.81f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        planet = GameObject.Find("Planet").GetComponent<Transform>();
    }
    void Start()
    {
        transform.rotation = Quaternion.FromToRotation(transform.up, (transform.position - planet.position.normalized).normalized);
    }
 

    private void FixedUpdate()
    {

        rb.AddForce((transform.position - planet.position).normalized * gravity * 100f);

        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, -(transform.position - planet.transform.position), out hit))
        //{
        //    //print("Found an object - distance: " + hit.distance);
        //    Debug.DrawRay(transform.position, -(transform.position - planet.transform.position) * hit.distance, Color.yellow);
        //    //Debug.Log(hit.distance);

        //    if(hit.distance >= 0 && transform.position.y > 0)
        //    {
        //        float offSet = transform.position.y - hit.distance;
        //        transform.position = new Vector3(transform.position.x,offSet,transform.position.z);
        //    }
        //    else if (hit.distance >= 0 && transform.position.y < 0)
        //    {
        //        Debug.Log(hit.distance);
        //        float offSet = (transform.position.y + planet.position.y) + hit.distance;
        //        transform.position = new Vector3(transform.position.x, offSet, transform.position.z);
        //    }
        //}

    }
}
