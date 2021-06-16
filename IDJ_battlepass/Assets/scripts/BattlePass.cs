using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class BattlePass
{
    private static int _playerPoints;
    public static Dictionary<int, Tier> tiers = new Dictionary<int, Tier>();

    public static int playerPoints
    {
        get => _playerPoints;
    } 

    public static void CalculateProgression()
    {
        int tempPoints = playerPoints;

        for (int i = 0; i < tiers.Count; i++)
        {
            tempPoints -= tiers[i].pointsRequired;

            if (tempPoints >= 0)
                tiers[i].isCompleted = true; 
            else
                tiers[i].isCompleted = false;
        }
    }

    public static int GetNumberOfTiersUnlocked()
    {
        int NumberOfTiersUnlocked = 0;

        for (int i = 0; i < tiers.Count; i++)
        {
            if (tiers[i].isCompleted == true)
                NumberOfTiersUnlocked++;
        }

        return NumberOfTiersUnlocked;
    }

    public static int GetPointsRequired(int tier)
    {
        int pointsRequired = 0;

        for (int i = 0; i <= tier; i++)
        {
            pointsRequired += tiers[i].pointsRequired;
        }

        return pointsRequired;
    }

    public static void AddPointsToPlayer(int points)
    {
        if(points > 0)
            _playerPoints += points;

        CalculateProgression();
        GetNumberOfTiersUnlocked();
    }

    public static void SetPlayerPoints(int points)
    {
        if (points > 0)
            _playerPoints = points;

        CalculateProgression();
        GetNumberOfTiersUnlocked();
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
}
