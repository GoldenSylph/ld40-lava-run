using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RollOutScript : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    private Color initialColor;

    void Start()
    {
        initialColor = GetComponent<MeshRenderer>().material.color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Roll out!");
        if (GIM.Instance != null)
        {
            GIM.Instance.gameInfo.reset();
        }
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("Game");
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
