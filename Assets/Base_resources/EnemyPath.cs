using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPath : MonoBehaviour
{
    NavMeshAgent agent;
    Transform currentPosition;
    [SerializeField] List<Transform> points;
    int point = 0;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentPosition = GetComponent<Transform>();
        agent.SetDestination(points[point].position);
        point++;
    }

    // Update is called once per frame
    void Update()
    {
        // other wall: if the target stop / repeat target.position coord
        if (point >= points.Count){
            point = 0;
        }

        if (Vector3.Distance(agent.destination, currentPosition.position) < 2.5f){
            agent.SetDestination(points[point].position);
            point++;
        }
    }
}
