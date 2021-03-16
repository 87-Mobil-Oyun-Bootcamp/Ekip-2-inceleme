using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpaceShip : MonoBehaviour
{
    Animator anim;

   public CinemachineVirtualCamera cinemachine;
    
    public Camera mainCam;
    public Camera spaceShipCam;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            mainCam.gameObject.SetActive(false);
            spaceShipCam.gameObject.SetActive(true);

            cinemachine.Follow = transform;
            cinemachine.LookAt = transform;
            PlayerController.Instance.gameObject.SetActive(false);

            anim.enabled = true;
            PlayerController.Instance.gameObject.transform.SetParent(transform);
            
        }
         
        if(Input.GetKeyDown(KeyCode.B))
        {
            mainCam.gameObject.SetActive(true);
            spaceShipCam.gameObject.SetActive(false);

            cinemachine.Follow = PlayerController.Instance.transform;
            cinemachine.LookAt = PlayerController.Instance.transform;
            PlayerController.Instance.gameObject.SetActive(true);

            anim.enabled = false;
            PlayerController.Instance.gameObject.transform.SetParent(null);
        }
    }
}
