using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission
{
    private string mission, name;
    private int pointsReward;
    private bool _isCompleted;

    public bool isCompleted
    {
        get => _isCompleted;
        set
        {
            _isCompleted = value;
        }
    }

    public Mission()
    {
        this.isCompleted = false;
    }

    Mission(int pointsReward, string mission, string name):base()
    {
        this.pointsReward = pointsReward;
        this.mission = mission;
        this.name = name;
    }

}
