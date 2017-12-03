using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseController : MonoBehaviour {

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            GIM.Instance.gameInfo.lost = true;
        }
    }

    void Update()
    {
        if (GIM.Instance.gameInfo.lost && !GIM.Instance.gameInfo.win)
        {
            Debug.Log("Loading fail info");
            FindObjectOfType<AudioManager>().Play("Fail");
            SceneManager.LoadScene("Lost");
            return;
        } else if (GIM.Instance.gameInfo.win && GIM.Instance.gameInfo.lost)
        {
            Debug.Log("Loading win info.");
            FindObjectOfType<AudioManager>().Play("Win");
            SceneManager.LoadScene("Won");
            return;
        }
    }

}
