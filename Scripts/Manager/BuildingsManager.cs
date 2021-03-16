using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingsManager : MonoBehaviour
{

    public List<Buildings> buildings;

    private void Start()
    {
        
    }

    //public void Part1Button()
    //{
    //    if(buildings[0].neededWood1 <= PlayerController.Instance.wood.amount)
    //    {
    //        buildings[0].part1.SetActive(true);
    //        PlayerController.Instance.wood.amount -= buildings[0].neededWood1;
    //        isPart1 = true;
    //        Debug.Log("Part1 Tamam");
    //    }
    //    else
    //    {
    //        Debug.Log("Not Enough Wood!");
    //    }

    //}

    //public void Part2Button()
    //{
    //    if (buildings[0].neededWood2 <= PlayerController.Instance.wood.amount && isPart1==true)
    //    {
    //        buildings[0].part2.SetActive(true);
    //        PlayerController.Instance.wood.amount -= buildings[0].neededWood2;
    //        isPart2 = true;
    //        Debug.Log("Part2 Tamam");
    //    }
    //    else
    //    {
    //        Debug.Log("Not Enough Wood!");
    //    }

    //}

    //public void Part3Button()
    //{
    //    if (buildings[0].neededWood3 <= PlayerController.Instance.wood.amount && isPart2==true)
    //    {
    //        buildings[0].part3.SetActive(true);
    //        PlayerController.Instance.wood.amount -= buildings[0].neededWood3;
    //        StartCoroutine(Part4());
    //        isPart1 = false;
    //        isPart2 = false;
    //        Debug.Log("Part2 Tamam");
    //    }
    //    else
    //    {
    //        Debug.Log("Not Enough Wood!");
    //    }

    //}

    //IEnumerator Part4()
    //{
    //    yield return new WaitForSeconds(1.5f);
    //    buildings[0].part1.SetActive(false);
    //    buildings[0].part2.SetActive(false);
    //    buildings[0].part3.SetActive(false);
    //    buildings[0].part4.SetActive(true);
    //    buildings.Remove(buildings[0]);
    //    yield return new WaitForSeconds(3f);
    //    buildings[0].part4.SetActive(false);
    //    //TO DO: Gerçek dünyada ana binayı SetActive(true) && Para kazanma
    //    constructions[0].constructionArea.SetActive(false);
    //    constructions[0].construction.SetActive(true);
    //    constructions.Remove(constructions[0]);
    //}

    private void Update()
    {
        for (int i = 0; i < buildings.Count; i++)
        {
            if (buildings[i].isCompleted && buildings.Count > i+1)
            {
                buildings[i + 1].gameObject.SetActive(true);
            }
            else
            {
                buildings[0].gameObject.SetActive(true);
            }
        }
    }
}
