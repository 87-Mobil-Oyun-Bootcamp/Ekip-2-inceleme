using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public static Axe Instance => instance;
    private static Axe instance;

    public int power;
    public int meleeSpeed;

    public GameObject[] axeModels;

    public ShopSystemSO axeData;

    public TreeManager currentTree;

    private void Awake()
    {     
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Update()
    {
        TreeDestroyed();

        power = axeData.shopItems[axeData.selectedIndex].axeLevel[axeData.shopItems[axeData.selectedIndex].unlockedLevel].power;
        meleeSpeed = axeData.shopItems[axeData.selectedIndex].axeLevel[axeData.shopItems[axeData.selectedIndex].unlockedLevel].speed;
        PlayerController.Instance.anim.SetFloat("MeleeSpeed", meleeSpeed);

        if(axeData.selectedIndex == 0)
        {
            foreach(GameObject axe in axeModels)
            {
                axe.gameObject.SetActive(false);
            }
            axeModels[0].gameObject.SetActive(true);
        }
        if (axeData.selectedIndex == 1)
        {
            foreach (GameObject axe in axeModels)
            {
                axe.gameObject.SetActive(false);
            }
            axeModels[1].gameObject.SetActive(true);
        }
        if (axeData.selectedIndex == 2)
        {
            foreach (GameObject axe in axeModels)
            {
                axe.gameObject.SetActive(false);
            }
            axeModels[2].gameObject.SetActive(true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            currentTree = other.gameObject.GetComponentInParent<TreeManager>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (currentTree != null && other.CompareTag("Tree"))
        {
            PlayerController.Instance.anim.SetBool("Melee", true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            PlayerController.Instance.anim.SetBool("Melee", false);
        }
    }

    private void OnNearTree()
    {
        if (currentTree != null)
        {
            currentTree.DecreaseWoodCount(power);

        }
    }

    private void TreeDestroyed()
    {
        if (currentTree != null && currentTree.TreeWoodCount <= 0)
        {
            currentTree = null;
            PlayerController.Instance.anim.SetBool("Melee", false);
        }
    }

}
