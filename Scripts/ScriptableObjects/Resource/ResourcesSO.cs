using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "ScriptableObjects/Resources")]
public class ResourcesSO : ScriptableObject
{
    public string name;
    public int amount;
}
