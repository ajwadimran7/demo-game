using UnityEngine;
using UnityEngine.SceneManagement;

public class f_MainMenu : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene(3);
    }

    public void Exit() {
        Application.Quit();
    }
}
