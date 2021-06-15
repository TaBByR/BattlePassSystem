using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward
{
    private bool isFree;
    private Sprite rewardImage;
    private GameObject rewardObject;
    private string rewardName;

    public Reward(bool isFree)
    {
        this.isFree = isFree;
    }

    public Reward(bool isFree, string rewardName):this(isFree)
    {
        this.rewardName = rewardName;
    }

    public Reward(bool isFree, string rewardName, Sprite rewardImage, GameObject rewardObject):this(isFree, rewardName)
    {
        this.rewardImage = rewardImage;
        this.rewardObject = rewardObject;
    }
}