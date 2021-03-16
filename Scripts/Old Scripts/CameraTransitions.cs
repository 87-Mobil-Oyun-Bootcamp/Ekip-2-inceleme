using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransitions : MonoBehaviour
{
    /* 
      README
     ---------
     - Add this script to main camera
     - If the "Shake()" is called, the camera shakes slightly in its local position. 
     - If the "MediumShake()" is called, the camera shakes more strongly in the local position. 
     (In addition, haptic feedback can be added.)
     --------- 
     */

    private float shakeAmount;

    private Vector3 startingLocalPos;

    void Update()
    {

        if (shakeAmount > 0.01f)
        {
            Vector3 localPosition = startingLocalPos;
            localPosition.x += shakeAmount * Random.Range(3, 5);
            localPosition.y += shakeAmount * Random.Range(3, 5);
          //  transform.localPosition = localPosition;
            shakeAmount = 0.9f * shakeAmount;
        }
    }

    // You can call it in other classes using the following method. ---> Camera.main.GetComponent<CameraTransitions>().Shake();
    public void Shake()
    {
        shakeAmount = Mathf.Min(0.1f, shakeAmount + 0.01f);
    }
    // You can call it in other classes using the following method. ---> Camera.main.GetComponent<CameraTransitions>().MediumShake();
    public void MediumShake()
    {
        shakeAmount = Mathf.Min(0.15f, shakeAmount + 0.015f);
    }
}