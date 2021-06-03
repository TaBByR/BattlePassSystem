using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier
{
    public GameObject _reward;
    private int _tierNumber;

    public GameObject reward
    {
        get => _reward;
        set
        {
            _reward = value;
        }
    }

    public Tier(int tierNumber)
    {
        this._tierNumber = tierNumber;
    }

    public Tier(int tierNumber, GameObject reward)
    {
        this._tierNumber = tierNumber;
        this.reward = reward;
    }
}
