using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class f_Level : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene(2);
    }

    public void Exit() {
        Application.Quit();
    }
}
