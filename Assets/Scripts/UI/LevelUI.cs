using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_ADS
using UnityEngine.Advertisements; // only compile Ads code on supported platforms
#endif

public class LevelUI : MonoBehaviour
{

    public GameObject gameoverUI;
    public Text gameover;

    // Start is called before the first frame update
    void Start()
    {
        gameoverUI.SetActive(false);
        EventManager.Instance.OnGameOver.AddListener(GameOver);
    }

    void GameOver(string msg) {
        gameoverUI.SetActive(true);
        gameover.text = msg;
        #if UNITY_ADS
        Advertisement.Show();
        #endif
        
    }
}
