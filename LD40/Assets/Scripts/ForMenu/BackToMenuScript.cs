using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackToMenuScript : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    private Color initialColor;

    void Start()
    {
        initialColor = GetComponent<MeshRenderer>().material.color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Back to the menu!");
        GIM.Instance.gameInfo.reset();
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("MainMenu");
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
