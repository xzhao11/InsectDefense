using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyPath : MonoBehaviour
{
    public bool gotEgg;
    public bool eggStolen;
    public Transform eggs;
    public Transform exit;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(eggs.position);
        gotEgg = false;
        eggStolen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.pathPending) return;
        
        if(gotEgg == false && agent.remainingDistance <= agent.stoppingDistance)
        {
            gotEgg = true;
            agent.SetDestination(exit.position);
        }
        else if (gotEgg == false)
        {
            agent.SetDestination(eggs.position);
        }
        else if (gotEgg == true && agent.remainingDistance <= agent.stoppingDistance)
        {
            eggStolen = true;
        }
        else
        {
            agent.SetDestination(exit.position);
        }
    }
}
