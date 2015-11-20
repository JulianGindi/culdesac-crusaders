using UnityEngine;
using System.Collections;


public class EnemyAIController : MonoBehaviour {
	
	public Transform[] points;
	public Transform player;

	// This is a variable for testing purposes. Should be removed before shipping the game.
	// Allows developer to turn off patrolling to test other AI interactions.
	public bool patrol = true;

	private int destPoint = 0;
	private NavMeshAgent agent;
	private bool foundBall;
	private AIVision aiVision;

	
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		aiVision = GetComponent<AIVision>();
		
		// Disabling auto-braking allows for continuous movement
		// between points (ie, the agent doesn't slow down as it
		// approaches a destination point).
		agent.autoBraking = false;

		foundBall = false;

		if (patrol == true)
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
		if (agent.remainingDistance < 0.5f && foundBall != true && patrol == true)
			GotoNextPoint();

		// Checking to see if player is in sight
		if (aiVision.playerInSight == true) {
			agent.destination = player.position;
		}

		// Check to see if player has hit car too many times (stupid test for now)
		if (GameManager.instance.playerInfamy > 5f)
			agent.destination = player.position;
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Baseball")) {
			foundBall = true;
			agent.destination = other.attachedRigidbody.position;
		}
	}
}