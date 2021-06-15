using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    public GameObject[] rewardsObj;
    public Sprite[] rewardsSprt;

    List<Reward> rewardList = new List<Reward>();


    // Start is called before the first frame update
    void Start()
    {
        GeneratePass(10);
        BattlePass.playerPoints = 50;
        BattlePass.CalculateProgression();

        BattlePass.AddTierAt(3, new Tier(3+1, 30));

        for (int i = 0; i < BattlePass.tiers.Count; i++)
        {
            Debug.Log("Estado do tier " + BattlePass.tiers[i].tierNumber + ": " + BattlePass.tiers[i].isCompleted + ". Eram precisos " + BattlePass.tiers[i].pointsRequired + " para completar.");
        }

        BattlePass.RemoveTierAt(5);

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

    void rewardMaker()
    {
        rewardList = new List<Reward>();

        for (int i = 0; i < 20; i++)
        {
            List<Sprite> Sprites = new List<Sprite>();
            List<GameObject> Obj = new List<GameObject>();
            Sprites.Add(rewardsSprt[Random.Range(0, rewardsSprt.Length)]);
            Obj.Add(rewardsObj[Random.Range(0, rewardsObj.Length)]);
            Reward r = new Reward(false, ("Reward " + i), Sprites, Obj, ("This is reward " + i));

            rewardList.Add(r);
        }

        rewardList[Random.Range(0, rewardList.Count)].isFree = true;
        rewardList[Random.Range(0, rewardList.Count)].isFree = true;
        rewardList[Random.Range(0, rewardList.Count)].isFree = true;
        rewardList[Random.Range(0, rewardList.Count)].isFree = true;
        rewardList[Random.Range(0, rewardList.Count)].isFree = true;
        rewardList[Random.Range(0, rewardList.Count)].isFree = true;

        rewardList[Random.Range(0, rewardList.Count)].AddObject(rewardsObj[Random.Range(0, rewardsObj.Length)]);
        rewardList[Random.Range(0, rewardList.Count)].AddObject(rewardsObj[Random.Range(0, rewardsObj.Length)]);
        rewardList[Random.Range(0, rewardList.Count)].AddObject(rewardsObj[Random.Range(0, rewardsObj.Length)]);
        rewardList[Random.Range(0, rewardList.Count)].AddObject(rewardsObj[Random.Range(0, rewardsObj.Length)]);
        rewardList[Random.Range(0, rewardList.Count)].AddObject(rewardsObj[Random.Range(0, rewardsObj.Length)]);
        rewardList[Random.Range(0, rewardList.Count)].AddObject(rewardsObj[Random.Range(0, rewardsObj.Length)]);
        rewardList[Random.Range(0, rewardList.Count)].AddObject(rewardsObj[Random.Range(0, rewardsObj.Length)]);
    }

    void AtributeRewardsToTiers()
    {
        for (int i = 0; i < BattlePass.tiers.Count; i++)
        {
            List<Reward> rewardsToTier = new List<Reward>();
            rewardsToTier.Add(rewardList[Random.Range(0, rewardList.Count)]);
            rewardsToTier.Add(rewardList[Random.Range(0, rewardList.Count)]);
        }
    }
}
