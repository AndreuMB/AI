using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    NavMeshAgent agentFollow;

	void Start ()
	{
        agent = GetComponent<NavMeshAgent>();
	}

    // Update is called once per frame
    void Update (){
        // Debug.Log("destination = " + agentFollow.destination);
        // Debug.Log("position = " + agentFollow.transform.position);
		agent.SetDestination(agentFollow.transform.position);
    }
}