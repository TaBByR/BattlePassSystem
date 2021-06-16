using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward
{
    private bool _isFree;
    private List<Sprite> _rewardImages;
    private List<GameObject> _rewardObjects;
    private string _rewardName, _rewardDescription;

    public string rewardName
    {
        get => _rewardName;
        set
        {
            _rewardName = value;
        }
    }

    public string rewardDescription
    {
        get => _rewardDescription;
        set
        {
            _rewardDescription = value;
        }
    }

    public bool isFree
    {
        get => _isFree;
        set
        {
            _isFree = value;
        }
    }

    public List<Sprite> rewardImages
    {
        get => _rewardImages;
    }

    public List<GameObject> rewardObjects
    {
        get => _rewardObjects;
    }

    public Reward(bool isFree)
    {
        this.isFree = isFree;
    }

    public Reward(bool isFree, string rewardName):this(isFree)
    {
        this.rewardName = rewardName;
    }

    public Reward(bool isFree, string rewardName, List<Sprite> rewardImages, List<GameObject> rewardObjects) : this(isFree, rewardName)
    {
        this._rewardImages = rewardImages;
        this._rewardObjects = rewardObjects;
    }

    public Reward(bool isFree, string rewardName, List<Sprite> rewardImages, List<GameObject> rewardObjects, string rewardDescription):this(isFree, rewardName)
    {
        this.rewardDescription = rewardDescription;
        this._rewardImages = rewardImages;
        this._rewardObjects = rewardObjects;
    }

    public void AddSprite(Sprite newImage)
    {
        rewardImages.Add(newImage);
    }

    public void RemoveSprite(int index)
    {
        rewardImages.RemoveAt(index);
    }

    public void AddObject(GameObject newObject)
    {
        rewardObjects.Add(newObject);
    }

    public void RemoveObject(int index)
    {
        rewardObjects.RemoveAt(index);
    }
}