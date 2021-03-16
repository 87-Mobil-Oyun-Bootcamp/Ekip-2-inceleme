using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{   
    public GameObject shopUI;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        shopUI.gameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        shopUI.gameObject.SetActive(false);
    }

}
