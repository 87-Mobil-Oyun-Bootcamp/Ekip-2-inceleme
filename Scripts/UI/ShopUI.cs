using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [Space] public int totalGold;
    [Space] public ShopSystemSO shopData;
    [Space] public GameObject[] axeModels;
    [Space] public TextMeshProUGUI unlockBtnText, upgradeBtnText, levelText, axeNameText;
    [Space] public TextMeshProUGUI speedText, powerText;
    [Space] public Button unlockBtn, upgradeBtn, nextBtn, previousBtn;

    [Space] public ResourcesSO gold;

    private int currentIndex = 0;
    private int selectedIndex = 0;

    private void Start()
    {
        totalGold = gold.amount;

        selectedIndex = shopData.selectedIndex;
        SetAxeInfo();

        unlockBtn.onClick.AddListener(() => UnlockSelectButton());
        upgradeBtn.onClick.AddListener(() => UpgradeButton());
        nextBtn.onClick.AddListener(() => NextButton());
        previousBtn.onClick.AddListener(() => PreviousButton());

        axeModels[currentIndex].SetActive(true);

        if (currentIndex == 0) previousBtn.interactable = false;
        if (currentIndex == shopData.shopItems.Length - 1) nextBtn.interactable = false;

        UnlockBtnStatus();
        UpgradeBtnStatus();
    }

    private void SetAxeInfo()
    {
        axeNameText.text = shopData.shopItems[currentIndex].itemName;
        int currentLevel = shopData.shopItems[currentIndex].unlockedLevel;
        levelText.text = "Level:" + (currentLevel + 1);
        speedText.text = "Speed:" + shopData.shopItems[currentIndex].axeLevel[currentLevel].speed;
        powerText.text = "Power" + shopData.shopItems[currentIndex].axeLevel[currentLevel].power;
    }

    private void NextButton()
    {
        if (currentIndex < shopData.shopItems.Length - 1)
        {
            axeModels[currentIndex].SetActive(false);
            currentIndex++;
            axeModels[currentIndex].SetActive(true);
            SetAxeInfo();

            if (currentIndex == shopData.shopItems.Length - 1) nextBtn.interactable = false;

            if (!previousBtn.interactable) previousBtn.interactable = true;

            UnlockBtnStatus();
            UpgradeBtnStatus();
        }


    }
    private void PreviousButton()
    {
        if (currentIndex > 0)
        {
            axeModels[currentIndex].SetActive(false);
            currentIndex--;
            axeModels[currentIndex].SetActive(true);
            SetAxeInfo();

            if (currentIndex == 0) previousBtn.interactable = false;

            if (!nextBtn.interactable) nextBtn.interactable = true;

            UnlockBtnStatus();
            UpgradeBtnStatus();

        }



    }
    private void UnlockSelectButton()
    {
        bool selected = false;

        if (shopData.shopItems[currentIndex].isUnlocked)
        {
            selected = true;
        }
        else
        {
            if (gold.amount >= shopData.shopItems[currentIndex].unlockCost)
            {
                gold.amount -= shopData.shopItems[currentIndex].unlockCost;
                selected = true;
                shopData.shopItems[currentIndex].isUnlocked = true;
                UpgradeBtnStatus();
            }
        }

        if (selected)
        {
            unlockBtnText.text = "Selected";
            selectedIndex = currentIndex;
            shopData.selectedIndex = selectedIndex;
            unlockBtn.interactable = false;
        }

    }

    private void UpgradeButton()
    {
        int nextLevelIndex = shopData.shopItems[currentIndex].unlockedLevel + 1;

        if (gold.amount >= shopData.shopItems[currentIndex].axeLevel[nextLevelIndex].unlockCost)
        {
            gold.amount -= shopData.shopItems[currentIndex].axeLevel[nextLevelIndex].unlockCost;
            shopData.shopItems[currentIndex].unlockedLevel++;

            if (shopData.shopItems[currentIndex].unlockedLevel < shopData.shopItems[currentIndex].axeLevel.Length - 1)
            {
                upgradeBtnText.text = "Upgrade Cost " + shopData.shopItems[currentIndex].axeLevel[nextLevelIndex + 1].unlockCost;
            }
            else
            {
                upgradeBtn.interactable = false;
                upgradeBtnText.text = "Max Level Reached";
            }
            SetAxeInfo();
        }
    }

    private void UnlockBtnStatus()
    {
        if (shopData.shopItems[currentIndex].isUnlocked)
        {

            if (selectedIndex == currentIndex)
                unlockBtn.interactable = false;
            else
                unlockBtn.interactable = true;

            if (selectedIndex == currentIndex)
                unlockBtnText.text = "Selected";
            else
                unlockBtnText.text = "Select";

        }
        else
        {
            unlockBtn.interactable = true;
            unlockBtnText.text = "Cost " + shopData.shopItems[currentIndex].unlockCost;
        }
    }

    private void UpgradeBtnStatus()
    {
        if (shopData.shopItems[currentIndex].isUnlocked)
        {
            if (shopData.shopItems[currentIndex].unlockedLevel < shopData.shopItems[currentIndex].axeLevel.Length - 1)
            {
                int nextLevelIndex = shopData.shopItems[currentIndex].unlockedLevel + 1;
                upgradeBtn.interactable = true;
                upgradeBtnText.text = "Upgrade Cost " + shopData.shopItems[currentIndex].axeLevel[nextLevelIndex].unlockCost;
            }
            else
            {
                upgradeBtn.interactable = false;
                upgradeBtnText.text = "Max Level Reached";
            }
        }
        else
        {
            upgradeBtn.interactable = false;
            upgradeBtnText.text = "Locked";
        }
    }
}

