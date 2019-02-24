using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent> ();
        agent.SetDestination(EnenmyManager.Instance.player.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.GameOver) {
            agent.Stop();
            return;
        }
    }

    public void KillMe() {
        EventManager.Instance.OnEnemyKilled.Invoke();
        agent.Stop();
        Destroy(this.gameObject);
    }
}
