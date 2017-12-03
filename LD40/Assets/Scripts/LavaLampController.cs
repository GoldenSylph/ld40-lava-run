using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LavaLampController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public float rotationSpeed;

    [HideInInspector]
    public Color initialColor;

    [HideInInspector]
    public Text lavaLevel;

    [HideInInspector]
    public Text lampsPicked;

    void Start()
    {
        initialColor = GetComponent<MeshRenderer>().material.color;
        lavaLevel = GameObject.FindGameObjectWithTag("TextLavaLevel").GetComponent<Text>();
        lampsPicked = GameObject.FindGameObjectWithTag("TextLampsCount").GetComponent<Text>();
    }

    void Update()
    {
        if (!GIM.Instance.gameInfo.lost)
        {
            transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
            lavaLevel.text = "Current lava level: " + GIM.Instance.gameInfo.lavaLevel;
            lampsPicked.text = "Lava lamps picked up: " + GIM.Instance.gameInfo.lamps + "/" + GIM.Instance.gameInfo.purpose;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!GIM.Instance.gameInfo.lost)
        {
            Debug.Log("Clicked!");
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform.parent;
            FindObjectOfType<AudioManager>().Play("PodMove");
            GIM.Instance.addLavaLamps(1);
            float level = 0.01f;
            GIM.Instance.addLavaLevel(level);
            GameObject.FindGameObjectWithTag("LavaOcean").transform.position += Vector3.up * level;
            Destroy(gameObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<MeshRenderer>().material.color = initialColor;
    }
}
