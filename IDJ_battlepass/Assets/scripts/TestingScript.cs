using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GeneratePass(10);
        Debug.Log("Tier: " + BattlePass.tiers[2].tierNumber + ". Pontos requeridos: " + BattlePass.tiers[2].pointsRequired);
        BattlePass.SetPlayerPoints(50);

        BattlePass.AddTierAt(3, new Tier(3+1, 30));

        for (int i = 0; i < BattlePass.tiers.Count; i++)
        {
            Debug.Log("Estado do tier " + BattlePass.tiers[i].tierNumber + ": " + BattlePass.tiers[i].isCompleted + ". Eram precisos " + BattlePass.tiers[i].pointsRequired + " para completar.");
        }
    }

    void GeneratePass(int amountOfTiers)
    {
        for (int i = 0; i < amountOfTiers; i++)
        {
            BattlePass.tiers.Add(i, new Tier(i + 1, 10));
        }
    }
}
