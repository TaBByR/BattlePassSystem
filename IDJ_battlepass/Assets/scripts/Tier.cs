using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier
{
    public Sprite _reward;
    private int _tierNumber;
    public static List<Tier> tiers = new List<Tier>();

    public Sprite reward
    {
        get => _reward;
        set
        {
            _reward = value;
        }
    }

    public int tierNumber
    {
        get => _tierNumber;
    }

    public Tier(int tierNumber)
    {
        this._tierNumber = tierNumber;
        tiers.Add(this);
    }

    public Tier(int tierNumber, Sprite reward)
    {
        this._tierNumber = tierNumber;
        this.reward = reward;
        tiers.Add(this);
    }
}
