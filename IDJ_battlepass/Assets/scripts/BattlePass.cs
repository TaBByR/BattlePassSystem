using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePass : MonoBehaviour
{
    public int amountOfTiers;
    //public Date

    private List<Tier> tiers = new List<Tier>();
    private List<MissionCollection> missionCollections = new List<MissionCollection>();
    private int playerPoints;

    private void Start()
    {
        playerPoints = 0;
    }

    private void GenerateTiers()
    {
        for (int i = 0; i < amountOfTiers; i++)
        {
            tiers.Add(new Tier(i+1));
        }
    }

    public void SetTierImage(GameObject obj, int tier)
    {
        tiers[tier].reward = obj;
    }

    public Tier GetTier(int tier)
    {
        return tiers[tier];
    }

    public void AddPlayerPoints(int points)
    {
        playerPoints += points;
    }
}
