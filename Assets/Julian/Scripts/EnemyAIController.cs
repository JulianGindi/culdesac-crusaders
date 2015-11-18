using UnityEngine;
using System.Collections;


public class EnemyAIController : MonoBehaviour {
	
	public Transform[] points;
	private int destPoint = 0;
	private NavMeshAgent agent;
	private bool foundBall;
	
	
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		
		// Disabling auto-braking allows for continuous movement
		// between points (ie, the agent doesn't slow down as it
		// approaches a destination point).
		agent.autoBraking = false;

		foundBall = false;
		GotoNextPoint();
	}
	
	
	void GotoNextPoint() {
		// Returns if no points have been set up
		if (points.Length == 0 || foundBall == true)
			return;
		
		agent.destination = points[destPoint].position;
		destPoint = (destPoint + 1) % points.Length;
	}
	
	
	void Update () {
		// Choose the next destination point when the agent gets
		// close to the current one.
		if (agent.remainingDistance < 0.5f && foundBall != true)
			GotoNextPoint();
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Baseball")) {
			foundBall = true;
			agent.destination = other.attachedRigidbody.position;
		}
	}
}