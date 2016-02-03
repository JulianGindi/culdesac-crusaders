using UnityEngine;
using System.Collections;

public class CameraProbe : MonoBehaviour {

    private BoxCollider probeCollider;
    public Camera cam;
    private Vector3[] targets;
    RaycastHit hit;

    // Use this for initialization
    void Start () {
        probeCollider = transform.GetComponent<BoxCollider>();
        
        
    }
	
	// Update is called once per frame
	void LateUpdate () {
        float adjustment = 0.2f;
        targets = new[] {
            probeCollider.transform.position + new Vector3(probeCollider.size.x * adjustment, 0f, probeCollider.size.z * adjustment),
            probeCollider.transform.position + new Vector3(-probeCollider.size.x * adjustment, 0f, probeCollider.size.z * adjustment),
            probeCollider.transform.position + new Vector3(-probeCollider.size.x * adjustment, 0f, -probeCollider.size.z * adjustment),
            probeCollider.transform.position + new Vector3(probeCollider.size.x * adjustment, 0f, -probeCollider.size.z * adjustment)
        };
        foreach (Vector3 vec in targets) {
            Debug.DrawLine(cam.transform.position + new Vector3(0,-5.0f,0), vec, Color.green);
            if (Physics.Linecast(cam.transform.position, vec, out hit))
            {
                //if (hit.collider.gameObject.tag == "NPC")
                //{
                    //Debug.Log("NPC");
                //}
            }
        }
    }
}
