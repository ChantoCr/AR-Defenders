using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public int goldAmount = 0;
    public TextMeshProUGUI goldText;

    void Start()
    {
        UpdateGoldUI(); // Start to update my gold count
        StartCoroutine(GoldIncrementCoroutine()); // Start to increment my gold
    }

    void UpdateGoldUI()
    {
        goldText.text = "Gold: " + goldAmount.ToString(); // Update UI Txt Gold amount
    }

    IEnumerator GoldIncrementCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(5); // How much time we need to wait for add gold
            AddGold(10); // Gold we gonna add after we wait the time for increment my gold
        }
    }

    public void AddGold(int amount)
    {
        goldAmount += amount;
        UpdateGoldUI(); // Update UI after we add gold
    }

    public bool SpendGold(int amount)
    {
        if (goldAmount >= amount)
        {
            goldAmount -= amount;
            UpdateGoldUI(); // Update UI after we spend gold
            return true;
        }
        return false; // No gold enough
    }
}
