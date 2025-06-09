using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) <= 0.5)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
