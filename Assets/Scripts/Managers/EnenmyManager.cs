using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenmyManager : MonoBehaviour
{

    public Transform player;
    public GameObject enemy;
    public Transform spawnPoint;

    public static EnenmyManager Instance;

    void Awake() {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy() {
        while(!GameManager.Instance.GameOver) {
            Instantiate(enemy, spawnPoint.position, Quaternion.identity);
            EventManager.Instance.OnEnemySpawn.Invoke();
            yield return new WaitForSeconds(1f);
        }
    }
}
