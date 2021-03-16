using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance => instance;

    private static PlayerController instance;

    Vector3 firstTouchPos = Vector3.zero;
    Vector3 deltaTouchPos = Vector3.zero;
    Vector3 direction = Vector3.zero;

    [Space]
    public Animator anim;

    [Space]
    public ResourcesSO wood;
    public ResourcesSO gold;

    [Space]
    public Transform modelRoot;

    public GameObject[] stackableLogs;

    public float moveSpeed = 7.5f;
    private float range = 50f;

    void Start()
    {
        wood = Resources.Load<ResourcesSO>("Resource/Wood");
        gold = Resources.Load<ResourcesSO>("Resource/Gold");

        instance = this;
    }

    void Update()
    {
        Move();
        StackLog();
    }
    private void Move()
    {
        // Parmağı kaydırdığımız miktarda animasyon hızını ayarlamak için, aşağıdaki iki değer lazım.
        float svermingSpeedz = direction.z * .006f;
        float svermingSpeedx = direction.x * .006f;

        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            deltaTouchPos = Input.mousePosition - firstTouchPos;
            direction = new Vector3(deltaTouchPos.x, 0f, deltaTouchPos.y);

            Vector3 moveForward = new Vector3(0f, 0f, direction.z).normalized;
            Vector3 moveRight = new Vector3(direction.x, 0f, 0f).normalized;
            Vector3 moveRotate = new Vector3(0f, direction.x, 0f).normalized;

            direction.z = Mathf.Abs(direction.z);
            if (direction.z >= range)
            {
                modelRoot.transform.localRotation = Quaternion.Euler(0, 0f, 0);
                transform.Translate(moveForward * moveSpeed * Time.deltaTime);
                anim.SetFloat("MoveSpeed", svermingSpeedz);
            }
            if (moveForward.z == -1f)
            {
                modelRoot.transform.localRotation = Quaternion.Euler(0, 180f, 0);
            }


            if (Mathf.Abs(deltaTouchPos.x) >= range * 3)
            {
                transform.Rotate(moveRotate * 150 * Time.deltaTime);

                transform.Translate(moveRight * moveSpeed * Time.deltaTime);
                if (deltaTouchPos.x > range)
                {
                    // moveSpeed = svermingSpeedx * 3;
                    transform.Rotate(moveRotate * 5 * Time.deltaTime);
                //    modelRoot.transform.localRotation = Quaternion.Euler(0, 90f, 0);
                    anim.SetFloat("MoveSpeed", svermingSpeedx);

                }
                else if (deltaTouchPos.x < range)
                {
                    // moveSpeed = -svermingSpeedx * 3;

                    anim.SetFloat("MoveSpeed", -svermingSpeedx);
                 //   modelRoot.transform.localRotation = Quaternion.Euler(0, -90f, 0);
                }

            }
        }
        else
        {
            anim.SetFloat("MoveSpeed", 0);
        }


    }

    private void StackLog()
    {
        if (wood.amount < 10)
        {
            foreach (GameObject stackableLog in stackableLogs)
            {
                stackableLog.gameObject.SetActive(false);
            }
        }
        if (wood.amount >= 10)
        {
            stackableLogs[0].gameObject.SetActive(true);
        }
        if (wood.amount >= 20)
        {
            stackableLogs[1].gameObject.SetActive(true);
        }
        if (wood.amount >= 30)
        {
            stackableLogs[2].gameObject.SetActive(true);
        }
        if (wood.amount >= 40)
        {
            stackableLogs[3].gameObject.SetActive(true);
        }
        if (wood.amount >= 50)
        {
            stackableLogs[4].gameObject.SetActive(true);
        }
        if (wood.amount >= 60)
        {
            stackableLogs[5].gameObject.SetActive(true);
        }
    }
}


