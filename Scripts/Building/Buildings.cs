using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    public GameObject completedStructure;

    [HideInInspector]
    public bool isCompleted;
    public int rewardCoin;

    BuildingArea buildingArea;
    GameObject completedParticles;

    private void Start()
    {
        buildingArea = GetComponentInChildren<BuildingArea>();
        completedParticles = Resources.Load<GameObject>("Buildings/ConfettiParticle");
    }
    private void Update()
    {
        if (buildingArea.neededWood == 0 && !buildingArea.isCompleted)
        {
            buildingArea.gameObject.SetActive(false);
            completedStructure.gameObject.SetActive(true);
            PlayerController.Instance.gold.amount += rewardCoin;
            buildingArea.isCompleted = true;
            isCompleted = true;
            Instantiate(completedParticles, transform.position, Quaternion.identity);

        }
    }
}
