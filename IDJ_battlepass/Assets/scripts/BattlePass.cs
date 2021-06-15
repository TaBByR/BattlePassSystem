using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class BattlePass
{
    public static int playerPoints;
    public static Dictionary<int, Tier> tiers = new Dictionary<int, Tier>();

    public static void CalculateProgression()
    {
        int tempPoints = playerPoints;

        for (int i = 0; i < tiers.Count; i++)
        {
            tempPoints -= tiers[i].pointsRequired;

            if (tempPoints - tiers[i].pointsRequired >= 0)
                tiers[i].isCompleted = true; 
            else
                tiers[i].isCompleted = false;
        }
    }

    public static void AddTierAt(int position, Tier tierToAdd)
    {
        for (int i = tiers.Count - 1; i >= position; i--)
        {
            Tier tierToUpdate = tiers[i];
            tierToUpdate.tierNumber++;

            tiers.Remove(i);
            tiers.Add(i + 1, tierToUpdate);
        }

        tiers.Add(position, tierToAdd);

        CalculateProgression();
    }

    public static void RemoveTierAt(int position)
    {
        tiers.Remove(position);

        for (int i = position + 1; i < tiers.Count + 1; i++)
        {
            Tier tierToUpdate = tiers[i];
            tierToUpdate.tierNumber--;

            tiers.Remove(i);
            tiers.Add(i - 1, tierToUpdate);
        }

        CalculateProgression();
    }

    /*private void PopulatePass()
    {
        GameObject[] TierImage = GameObject.FindGameObjectsWithTag("TierImage");
        GameObject[] TierText = GameObject.FindGameObjectsWithTag("TierText");

        for (int i = 0; i < TierText.Length; i++)
        {
            TierText[i].GetComponent<TextMeshProUGUI>().text = Tier.tiers[i + page * 5].tierNumber.ToString();
            TierImage[i].GetComponent<Image>().sprite = Tier.tiers[i + page * 5].reward;
        }
        
    }

    public void NextPage()
    {
        page++;
        PopulatePass();
    }

    public void PreviousPage()
    {
        if (page > 0)
        {
            page--;
            PopulatePass();
        }
    }*/
}
