using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{

    public Camera baseCam;
    public Camera worldCam;
    public GameObject baseUI;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("girdin");
          
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                worldCam.gameObject.SetActive(false);
                baseCam.gameObject.SetActive(true);
                baseUI.gameObject.SetActive(true);
                Debug.Log("b");
            }
        }
      
    }
}
