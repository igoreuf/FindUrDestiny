using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
