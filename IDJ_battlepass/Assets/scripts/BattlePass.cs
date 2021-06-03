using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattlePass : MonoBehaviour
{
    public int amountOfTiers;
    public bool generateWithRewards;
    public Sprite[] rewards;
    
    public static int page = 0;
    private List<MissionCollection> missionCollections = new List<MissionCollection>();
    private int playerPoints;

    private void Start()
    {
        playerPoints = 0;
        if (generateWithRewards)
        {
            GenerateTiers(rewards);
            PopulatePass();
        }
        else
        {
            GenerateTiers();
            PopulatePass();
        }
    }

    private void GenerateTiers()
    {
        for (int i = 0; i < amountOfTiers; i++)
        {
            new Tier(i+1);
        }
    }

    private void GenerateTiers(Sprite[] r)
    {
        for (int i = 0; i < amountOfTiers; i++)
        {
            new Tier(i + 1, r[i]);
        }
    }

    private void PopulatePass()
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
    }
}
