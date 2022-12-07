using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEngine.AI;

public class Chase : ActionNode
{
    NavMeshAgent agent;
    GameObject agentFollow;
    GameObject[] players;
    
    protected override void OnStart() {
        agent = context.gameObject.GetComponent<NavMeshAgent>();
        players = GameObject.FindGameObjectsWithTag("Player");
        // agent = getClosestPlayer();
        agentFollow = getClosestPlayer();
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (agentFollow)
        {
            agent.SetDestination(agentFollow.transform.position);
            return State.Running;
        }
        // agent.isStopped=true;
        return State.Success;
    }

    GameObject getClosestPlayer(){
        Vector3 selfPosition = context.transform.position;
        GameObject tMin = null;
        foreach (GameObject player in players)
        {
            if (context.gameObject != player)
            {
                tMin = player;
            }
        }
        return tMin;
    }
}
