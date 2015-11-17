using UnityEngine;
using System.Collections;

public class AnimationDelegate : MonoBehaviour {

    Animator anim;
    Rigidbody rb;
    public float walkingSpeedMultipler;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 speedVector = new Vector3(moveHorizontal, 0, moveVertical);
        float speedMagnitude = Vector3.Magnitude(speedVector);
        anim.SetFloat("Speed", speedMagnitude);
        anim.SetFloat("SpeedMultiplier", walkingSpeedMultipler);
    }
}
