using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestingScript : MonoBehaviour
{
    public GameObject[] rewardsObj;
    public Sprite[] rewardsSprt;

    List<Reward> rewardList = new List<Reward>();
    int page = 0;


    // Start is called before the first frame update
    void Start()
    {
        GeneratePass(70);
        BattlePass.SetPlayerPoints(30);
        BattlePass.CalculateProgression();

        rewardMaker();
        AtributeRewardsToTiers();
        PopulatePass();

        for (int i = 0; i < BattlePass.tiers.Count; i++)
        {
            Debug.Log("Estado do tier " + BattlePass.tiers[i].tierNumber + ": " + BattlePass.tiers[i].isCompleted + ". Eram precisos " + BattlePass.tiers[i].pointsRequired + " pontos para completar.");
        }

        // BattlePass.AddPointsToPlayer(30);

        // BattlePass.SetPlayerPoints(10);

        /*
        Tier t = new Tier(2 + 1, 20);
        t.AddReward(rewardList[0]);
        t.AddReward(rewardList[1]);
        t.rewards[0].isFree = false;
        t.rewards[1].isFree = true;
        BattlePass.AddTierAt(2, t);
        */

        /*
        BattlePass.tiers[2].rewards[0].rewardName = "Recompensa 1";
        BattlePass.tiers[2].rewards[1].rewardName = "Recompensa 2";
        BattlePass.tiers[2].rewards[0].rewardDescription = "Esta é a recompensa 1";
        BattlePass.tiers[2].rewards[1].rewardDescription = "Esta é a recompensa 2";
        Debug.Log(GetRewardsInformation(2));
        */

        //BattlePass.tiers[2].pointsRequired = 100;

        //BattlePass.RemoveTierAt(2);


        PopulatePass();
    }

    void GeneratePass(int amountOfTiers)
    {
        for (int i = 0; i < amountOfTiers; i++)
        {
            BattlePass.tiers.Add(i, new Tier(i + 1, (int)Random.Range(1, 11)));
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

            BattlePass.tiers[i].AddReward(rewardsToTier[0]);
            BattlePass.tiers[i].AddReward(rewardsToTier[1]);
        }
    }

    private void PopulatePass()
    {
        GameObject[] TierImage = GameObject.FindGameObjectsWithTag("TierImage");
        GameObject[] FreeTierImage = GameObject.FindGameObjectsWithTag("FreeTierImage");
        GameObject[] TierText = GameObject.FindGameObjectsWithTag("TierText");
        GameObject[] StateImage = GameObject.FindGameObjectsWithTag("stateImage");
        GameObject[] PointsRequiredText = GameObject.FindGameObjectsWithTag("PointsRequired");

        for (int i = 0; i < 5; i++)
        {
            TierImage[i].GetComponent<Image>().sprite = null;
            FreeTierImage[i].GetComponent<Image>().sprite = null;
            StateImage[i].GetComponent<Image>().color = new Color(0, 0, 0, 0.0f);
            TierText[i].GetComponent<TextMeshProUGUI>().text = "";
            PointsRequiredText[i].GetComponent<TextMeshProUGUI>().text = "";
        }

        for (int i = 0; i < 5; i++)
        {
            if(i + page * 5 >= BattlePass.tiers.Count)
            {
                // Não consegui fazer esconder totalmente o UI de tiers que não existem
            }
            else
            {
                TierText[i].GetComponent<TextMeshProUGUI>().text = BattlePass.tiers[i + page * 5].tierNumber.ToString();
                PointsRequiredText[i].GetComponent<TextMeshProUGUI>().text = "Points Required: " + BattlePass.GetPointsRequired(i + page * 5).ToString();
                GameObject.Find("Points").GetComponent<TextMeshProUGUI>().text = BattlePass.playerPoints.ToString();
                GameObject.Find("TiersUnlocked").GetComponent<TextMeshProUGUI>().text = BattlePass.GetNumberOfTiersUnlocked().ToString();

                if (BattlePass.tiers[i + page * 5].isCompleted == true)
                    StateImage[i].GetComponent<Image>().color = new Color(0, 255, 0, 0.5f);
                else
                    StateImage[i].GetComponent<Image>().color = new Color(255, 0, 0, 0.5f);



                for (int k = 0; k < BattlePass.tiers[i + page * 5].rewards.Count; k++)
                {
                    if (BattlePass.tiers[i + page * 5].rewards[k].isFree == true)
                        FreeTierImage[i].GetComponent<Image>().sprite = BattlePass.tiers[i + page * 5].rewards[k].rewardImages[0];
                    else
                        TierImage[i].GetComponent<Image>().sprite = BattlePass.tiers[i + page * 5].rewards[k].rewardImages[0];
                }
            }
            
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

    string GetRewardsInformation(int tierIndex)
    {
        string returnString = "O tier " + BattlePass.tiers[tierIndex].tierNumber + " tem as seguintes recompensas: \n";

        for (int i = 0; i < BattlePass.tiers[tierIndex].rewards.Count; i++)
        {
            returnString += "Nome : " + BattlePass.tiers[tierIndex].rewards[i].rewardName;
            returnString += ". Descrição: " + BattlePass.tiers[tierIndex].rewards[i].rewardDescription + "\n";
        }

        return returnString;
    }
}
