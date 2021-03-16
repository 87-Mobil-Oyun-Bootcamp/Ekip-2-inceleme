using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ShopData", menuName = "ScriptableObjects/ShopData")]
public class ShopSystemSO : ScriptableObject
{
    public int selectedIndex;
    public ShopItem[] shopItems;
}

[System.Serializable]
public class ShopItem
{
    public string itemName;
    public bool isUnlocked;
    public int unlockCost;
    public int unlockedLevel;
    public AxeInfo[] axeLevel;
}

[System.Serializable]
public class AxeInfo
{
    public int unlockCost;
    public int speed;
    public int power;
}

