using UnityEngine;
using UnityEngine.SceneManagement;
public class Win : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
