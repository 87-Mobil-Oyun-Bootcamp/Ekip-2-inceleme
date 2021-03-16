using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    [Space]
    [SerializeField]
    private float moveSpeed = 1f;

    [Space]
    [SerializeField]
    private float moveRotateSpeed = 50f;

    Rigidbody body;

    public Transform planet;
    float gravity = -9.81f;

    float rotateSpeed = 50f;

    Vector3 firstTouchPos = Vector3.zero;
    Vector3 deltaTouchPos = Vector3.zero;
    Vector3 direction = Vector3.zero;

    [SerializeField]
    float range = 50f;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            deltaTouchPos = Input.mousePosition - firstTouchPos;
            direction = new Vector3(deltaTouchPos.x, 0f, deltaTouchPos.y);
            //  Debug.Log(direction+"direction");

            Vector3 moveForward = new Vector3(0f, 0f, direction.z).normalized;
            Vector3 moveRotate = new Vector3(0f, direction.x, 0f).normalized;


            if (Mathf.Abs(deltaTouchPos.y) >= range * .5)
            {
                transform.Translate(moveForward * moveSpeed * Time.deltaTime);

            }

            if (Mathf.Abs(deltaTouchPos.x) >= range)
            {
                transform.Rotate(moveRotate * moveRotateSpeed * Time.deltaTime);
            }



            body.AddForce((this.transform.position - planet.position).normalized * gravity);

            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.FromToRotation(transform.up,
                 (transform.position - planet.position).normalized) * transform.rotation, rotateSpeed * Time.deltaTime);





        }
        else
        {
            body.velocity = Vector3.zero;
        }
    }
}
