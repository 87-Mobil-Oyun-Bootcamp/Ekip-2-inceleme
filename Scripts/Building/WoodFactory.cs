using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodFactory : MonoBehaviour
{
    [HideInInspector] public int woodAmount;
    public int maxAmount;
    public float generateTime;

    private bool isCoroutineStarted;
    private bool isTrigged;

    public TextMesh woodAmountText;

    void Start()
    {
        woodAmountText = GetComponentInChildren<TextMesh>();
    }
    private void Update()
    {
        if (woodAmount == 0 && !isTrigged)
        {
            isCoroutineStarted = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isTrigged = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.Instance.wood.amount += woodAmount;
            woodAmount = 0;
            isTrigged = true;
            if (!isCoroutineStarted && isTrigged)
            {
                StartCoroutine(GenerateWood());
            }
            else if (isCoroutineStarted && isTrigged)
            {
                StopAllCoroutines();
                StartCoroutine(GenerateWood());
            }

        }
    }

    IEnumerator GenerateWood()
    {
        isCoroutineStarted = true;
        while (woodAmount < maxAmount)
        {
            woodAmount++;
            woodAmountText.text = woodAmount.ToString();
            yield return new WaitForSeconds(generateTime);
        }
    }

}
