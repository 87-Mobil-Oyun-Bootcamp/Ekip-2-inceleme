using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpaceShipBody : MonoBehaviour
{
    Rigidbody rigidbody;
    FakeGravityAttractor attractor;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        rigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(attractor != null)
        {
            attractor.Attract(transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Planet"))
        {
            attractor = other.gameObject.GetComponentInParent<FakeGravityAttractor>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Planet"))
        {

        }
    }
}
