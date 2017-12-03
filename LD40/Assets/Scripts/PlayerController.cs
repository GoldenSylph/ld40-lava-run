using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speedOfMoving;
    public float speedOfRotating;
    public float heightOfFloat;

    [HideInInspector]
    public Text distanceToDangerZone;

    void Start()
    {
        distanceToDangerZone = GameObject.FindGameObjectWithTag("TextHeat").GetComponent<Text>();
        Debug.Log(distanceToDangerZone);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit!");
            Application.Quit();
        }

        if (!GIM.Instance.gameInfo.lost)
        {
            Vector3 playerPos = transform.position;
            Vector3[] dangerZones = new Vector3[2];
            GameObject[] tempZones = GameObject.FindGameObjectsWithTag("DangerTrigger");
            dangerZones[0] = tempZones[0].transform.position;
            dangerZones[1] = tempZones[1].transform.position;
            int firstDistance = (int)Vector3.Distance(playerPos, dangerZones[0]);
            int secondDistance = (int)Vector3.Distance(playerPos, dangerZones[1]);
            if (firstDistance > secondDistance)
            {
                distanceToDangerZone.text = "Distance to closest danger zone: " + secondDistance;
            }
            else
            {
                distanceToDangerZone.text = "Distance to closest danger zone: " + firstDistance;
            }
            transform.position = Vector3.Lerp(transform.position,
            transform.parent.position + Vector3.up * heightOfFloat, speedOfMoving * Time.deltaTime);
            transform.Rotate(new Vector3(0, 0, Input.GetAxis("Horizontal")) * Time.deltaTime * speedOfRotating);
        }
    }
}
