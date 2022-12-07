using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum State{
    idle=0,
    walk=1,
    alert=2,
    run=3,
}
public class FSMEnemy : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    NavMeshAgent agentFollow;
    GameObject player;

    [SerializeField] State state = State.idle;

    State lastState;
    float timer = 0;
    bool swWalk = false;
        
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float playerDistance = Vector3.Distance(agentFollow.transform.position, transform.position);
        
        if (timer>5){
            swWalk = true;
        }

		if (playerDistance<5){
            swWalk = false;
            if (player.GetComponent<EatPill>().getActive()){
                state = State.run;
            }else{
                state = State.alert;
            }
		}else if (playerDistance>5 && !swWalk){
            state = State.idle;
        }else if(swWalk){
            timer = 0;
            state = State.walk;
        }

        if (state == lastState){
            return;
        }else{
            // if (lastState == State.alert)
            // {
            //     timer = 0; // when alert end reset timer
            // }
            lastState = state;
        }

        GetComponent<FollowPlayer>().enabled = false;
        GetComponent<EnemyPath>().enabled = false;
        GetComponent<RunPlayer>().enabled = false;

        switch (state){
            case State.idle:
                idleUpdate();
            break;
            case State.walk:
                walkUpdate();
            break;
            case State.alert:
                alertUpdate();
            break;
            case State.run:
                runUpdate();
            break;
            default:
                walkUpdate();
            break;
        }
    }

    void idleUpdate(){
        Debug.Log("idle");
        agent.SetDestination(GetComponent<Transform>().position);
    }

    void walkUpdate(){
        Debug.Log("walk");
        GetComponent<EnemyPath>().enabled = true;
    }

    void alertUpdate(){
        Debug.Log("alert");
        GetComponent<FollowPlayer>().enabled = true;
    }

    void runUpdate(){
        Debug.Log("run");
        GetComponent<RunPlayer>().enabled = true;
    }
}
