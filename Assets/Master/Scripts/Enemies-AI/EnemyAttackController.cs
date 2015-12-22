using UnityEngine;
using System.Collections;

public class EnemyAttackController : MonoBehaviour {

	public float launchAngle = 25f;
	public float launchForce = 10f;

	public Transform spawnLocationObj;

	public GameObject attackObject;
	
	public void AttackPlayer(Transform playerToAttack) {
		Vector3 forwards = transform.forward; // get the forward direction
		Vector3 dir = new Vector3(forwards.x, 0f, forwards.z); // keep it in the horizontal plane
		Vector3 norm = dir.normalized;
		norm.y = Mathf.Sin(launchAngle * Mathf.Deg2Rad); // set the desired elevation angle
		
		// Now we will create an instance of whatever the 'current prank' is
		GameObject thrownObject = Instantiate(attackObject, spawnLocationObj.transform.position, transform.rotation) as GameObject;
		thrownObject.SetActive(true);
		thrownObject.GetComponent<Rigidbody>().velocity = launchForce * norm.normalized;
	}
}
