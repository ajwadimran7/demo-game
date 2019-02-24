using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public bool GameOver = false;

    int maxEnemyCount = 10;
    int numberOfEnemiesToKill = 20;
    int killedEnemyCount = 0;
    int currentEnemyCount= 0;

    string gameoverText = "You lost!";

    void Awake() {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SubscribeToEvents();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(0);
        }
    }

    void AddEnemy() {
        currentEnemyCount++;
        GameLoop();
    }

    void SubtractEnemy() {
        currentEnemyCount--;
        killedEnemyCount++;
        GameLoop();
    }

    void GameLoop() {
        Debug.Log("Kill Count: "+ killedEnemyCount +"\n Current Enemy Count: "+ currentEnemyCount);
        if(killedEnemyCount >= numberOfEnemiesToKill){
            GameOver = true;
            gameoverText = "You Won!";
            EventManager.Instance.OnGameOver.Invoke(gameoverText);
        } else if(currentEnemyCount > maxEnemyCount) {
            GameOver = true;
            gameoverText = "You lost!";
            EventManager.Instance.OnGameOver.Invoke(gameoverText);
        }
    }

    void SubscribeToEvents() {
        EventManager.Instance.OnEnemySpawn.AddListener(AddEnemy);
        EventManager.Instance.OnEnemyKilled.AddListener(SubtractEnemy);
    }
}
