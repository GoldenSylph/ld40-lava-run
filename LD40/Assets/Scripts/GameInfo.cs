using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameInfo {

    public float lavaLevel;
    public int lamps;
    public float playingTime;
    public bool lost;
    public bool win;
    public int purpose;

    public void reset()
    {
        lavaLevel = 0;
        lamps = 0;
        playingTime = 0;
        lost = false;
        win = false;
        purpose = 100;
    }

}
