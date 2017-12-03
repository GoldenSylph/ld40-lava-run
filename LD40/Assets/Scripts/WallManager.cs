using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour {

    public GameObject[] platforms;

    public float rangeOfHeight;
    public float speedOfGrowingSpeed;
    public float minHeight;
    public float distanceFromBeginWall;
    public float distanceBetweenPlatforms;
    public float delayBetweenPlatforms;

    public int positionsLength;
    public int maxSpeed;

    private float timer;
    private const float step = 0.01f;

    [HideInInspector]
    public Vector3[] positions;

    
    void Start()
    {

        positions = new Vector3[positionsLength];
        for (int i = 0, j = -positions.Length / 2; i < positions.Length; i++, j++)
        {
            positions[i] = new Vector3(j * distanceBetweenPlatforms, minHeight, -distanceFromBeginWall);
        }
        timer = delayBetweenPlatforms;
    }

    void Update()
    {
        if (!GIM.Instance.gameInfo.lost)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                GameObject plat = Instantiate(platforms[Random.Range(0, platforms.Length)],
                      positions[Random.Range(0, positions.Length)]
                          + new Vector3(0, Random.Range(-rangeOfHeight, rangeOfHeight), 0),
                              Quaternion.identity * Quaternion.Euler(new Vector3(-90, 0, 0)));
                float tempSpeed = growSpeed(step);
                if (tempSpeed + step < maxSpeed)
                {
                    plat.GetComponent<PlatformMover>().speedRange += tempSpeed;
                }
                else
                {
                    tempSpeed = 0;
                }
                timer = delayBetweenPlatforms - tempSpeed;

            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log("Wall Trigger!");
        Destroy(coll.gameObject);
    }

    private float growSpeed(float step)
    {
        speedOfGrowingSpeed += step;
        return speedOfGrowingSpeed;
    }

}
