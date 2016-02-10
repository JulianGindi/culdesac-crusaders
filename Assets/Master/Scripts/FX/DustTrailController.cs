using UnityEngine;
using System.Collections;

public class DustTrailController : MonoBehaviour {

    GameObject ps;

    // Use this for initialization
    void Start () {
        ps = transform.Find("Dust Trail").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        if (movement.magnitude > 0.5)
        {
            ps.SetActive(true);
        }
        else {
            ps.SetActive(false);
        }
    }
}
