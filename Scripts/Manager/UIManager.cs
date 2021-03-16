using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{


    public GameObject dragToPlayUI;

    public Text woodText;
    public Text goldText;

    private float timer;
    private bool dragToPlay;

    private void Start()
    {
        dragToPlayUI.gameObject.SetActive(true);
    }
    private void Update()
    {
        UpdateResources();

        if (Input.GetMouseButton(0) && !dragToPlay)
        {
            timer += Time.deltaTime;
            if (timer >= .5f)
            {
                dragToPlay = true;
                dragToPlayUI.gameObject.SetActive(false);

            }
        }
        else if(!dragToPlay)
        {
            timer = 0;
        }
    }
    private void UpdateResources()
    {
        woodText.text = PlayerController.Instance.wood.amount.ToString();
        goldText.text = PlayerController.Instance.gold.amount.ToString();
    }
}
