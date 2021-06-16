using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier
{
    private int _tierNumber;
    private bool _isCompleted;
    private int _pointsRequired;
    public List<Reward> rewards = new List<Reward>();

    public int tierNumber
    {
        get => _tierNumber;
        set
        {
            _tierNumber = value;

        }
    }

    public int pointsRequired
    {
        get => _pointsRequired;
        set
        {
            _pointsRequired = value;
        }
    }
    public bool isCompleted
    {
        get => _isCompleted;
        set
        {
            _isCompleted = value;
        }
    }

    public Tier(int tierNumber, int pointsRequired)
    {
        this.pointsRequired = pointsRequired;
        this._tierNumber = tierNumber;
        this.isCompleted = false;
    }

    public Tier(int tierNumber, int pointsRequired, List<Reward> rewards)
    {
        this.pointsRequired = pointsRequired;
        this._tierNumber = tierNumber;
        this.isCompleted = false;
        this.rewards = rewards;
    }

    public void AddReward(Reward newReward)
    {
        rewards.Add(newReward);
    }

    public void RemoveReward(int index)
    {
        rewards.RemoveAt(index);
    }
}
