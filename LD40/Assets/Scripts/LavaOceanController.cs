using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaOceanController : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            GIM.Instance.gameInfo.lost = true;
        }
    }
}
