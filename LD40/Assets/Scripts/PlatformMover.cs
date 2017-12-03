using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour {


    public float speed;
    public float rotation;
    public GameObject BeginWall;
    public GameObject itemSlot;

    [HideInInspector]
    public float speedRange;

    [HideInInspector]
    public Vector3 floatingPoint;

    void Awake()
    {
        bool isNotPlayer = !itemSlot.CompareTag("Player");
        if (isNotPlayer)
        {
            itemSlot = Instantiate(itemSlot);
        }
        floatingPoint = transform.position + Vector3.up;
        itemSlot.transform.SetParent(transform);
        itemSlot.transform.position = floatingPoint;
    }

    // Update is called once per frame
    void Update () {
        if (!GIM.Instance.gameInfo.lost)
        {
            floatingPoint = transform.position + new Vector3(0, 3f, 0);
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(transform.position.x, transform.position.y, BeginWall.transform.position.z),
                    (speed + speedRange));
            transform.Rotate(new Vector3(0, 0, rotation));
        }
    }
}
