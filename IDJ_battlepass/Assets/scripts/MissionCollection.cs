using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCollection
{
    private List<Mission> missions;
    private int _collectionNumber;
    private bool _isUnlocked;

    public bool isUnlocked
    {
        get => isUnlocked;
        set
        {
            _isUnlocked = value;
        }
    }

    MissionCollection()
    {
        this._isUnlocked = false;
    }

    public MissionCollection(int collectionNumber) : base()
    {
        this._collectionNumber = collectionNumber;
    }

    public MissionCollection(int collectionNumber, List<Mission> missions) : base()
    {
        this._collectionNumber = collectionNumber;
        this.missions = missions;
    }

    public void AddMission(Mission m)
    {
        missions.Add(m);
    }
}
