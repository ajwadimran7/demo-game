using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public UnityEvent OnEnemySpawn;
    public UnityEvent OnEnemyKilled;

    public StringEvent OnGameOver;

    void Awake() {
        Instance = this;
    }
}

[System.Serializable]
public class StringEvent : UnityEvent<string> {

}
