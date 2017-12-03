using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIM : MonoBehaviour
{
    private static GIM instance_;
    public static GIM Instance
    {
        get
        {
            if (instance_ == null)
                instance_ = GameObject.FindObjectOfType<GIM>();
            return instance_;
        }
    }

    public GameInfo gameInfo = new GameInfo();

    public void Awake()
    {
        if (instance_ != null && instance_ != this)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    public void Update()
    {
        gameInfo.playingTime = Time.time;
    }

    public void addLavaLevel(float level)
    {
        gameInfo.lavaLevel += level;
    }

    public void addLavaLamps(int lamps)
    {
        gameInfo.lamps += lamps;
        if (gameInfo.lamps == gameInfo.purpose)
        {
            gameInfo.lost = true;
            gameInfo.win = true;
        }
    }
}

