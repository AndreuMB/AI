using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEngine.AI;

public class Eat : ActionNode
{
    GameObject[] fruits;
    GameObject player;
    GameObject closest;
    NavMeshAgent agent;
    protected override void OnStart() {
        player = GameObject.FindWithTag("Player");
        // fruits = GameObject.FindGameObjectsWithTag("Fruit");
        // if (fruits.Length>0)
        // {
        //     closest = getClosestFruit();
        //     agent = context.gameObject.GetComponent<NavMeshAgent>();
        //     agent.SetDestination(closest.transform.position);
        // }
        
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        // other player can destroy the object
        fruits = GameObject.FindGameObjectsWithTag("Fruit");
        if (fruits.Length>0)
        {
            closest = getClosestFruit();
            agent = context.gameObject.GetComponent<NavMeshAgent>();
            agent.SetDestination(closest.transform.position);
        }

        if(agent.hasPath && agent.remainingDistance<1) { // check destination
            return State.Success;
        }else{
            return State.Running;
        }

    }

    GameObject getClosestFruit(){
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 selfPosition = context.transform.position;
        foreach (GameObject fruit in fruits)
        {
            float dist = Vector3.Distance(fruit.transform.position, selfPosition);
            if (dist < minDist)
            {
                tMin = fruit;
                minDist = dist;
            }
        }
        return tMin;
    }
}
