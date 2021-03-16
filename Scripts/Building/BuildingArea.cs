using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingArea : MonoBehaviour
{
    [HideInInspector]
    public bool isCompleted;
    public int neededWoodStartValue;
    [HideInInspector]
    public int neededWood;
    [HideInInspector]
    public int increaseAmount;

    private bool isInTrigger;

    TextMesh neededWoodText;
    int increaseValue;

    public List<GameObject> parts;

    void Start()
    {
        increaseAmount = (neededWoodStartValue / 2) / parts.Count;
        neededWood = neededWoodStartValue;
        neededWoodText = GetComponentInChildren<TextMesh>();
    }


    void Update()
    { 
        if (neededWoodStartValue != neededWood)
        {
            foreach (GameObject part in parts)
            {
                part.gameObject.SetActive(false);
            }
        }

        if (increaseValue > increaseAmount)
        {
            if (parts.Count != 0)
            {
                parts[0].gameObject.SetActive(true);
                parts.Remove(parts[0]);
                increaseValue = 0;
            }
        }

        neededWoodText.text = neededWood.ToString();
    }

private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        isInTrigger = true;
        StartCoroutine(BuildingStructure());
    }
}
private void OnTriggerExit(Collider other)
{
        if(other.gameObject.CompareTag("Player"))
        {
            isInTrigger = false;
        }
        
}
IEnumerator BuildingStructure()
{
    while (true)
    {
        if (PlayerController.Instance.wood.amount > 0 && neededWood > 0)
        {
            neededWood--;
            increaseValue++;
            PlayerController.Instance.wood.amount--;
            yield return new WaitForSeconds(.05f);
        }

        if (PlayerController.Instance.wood.amount <= 0 || neededWood <= 0 || !isInTrigger)
        {
            break;
        }
    }
}
}
