using UnityEngine;
using UnityEngine.EventSystems;

public class ExitScript : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    private Color initialColor;

    void Start()
    {
        initialColor = GetComponent<MeshRenderer>().material.color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Exit");
        FindObjectOfType<AudioManager>().Play("Click");
        Application.Quit();
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
