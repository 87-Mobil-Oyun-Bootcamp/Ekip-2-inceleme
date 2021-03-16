using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWoodPanel : MonoBehaviour
{

    Quaternion originalRotation;

    private void Start()
    {
        originalRotation = transform.rotation;
    }

    private void Update()
    {
        transform.rotation = PlayerController.Instance.gameObject.transform.rotation * originalRotation;
    }

}
