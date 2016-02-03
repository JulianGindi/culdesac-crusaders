using UnityEngine;
using System.Collections;

public class AlphaControl : MonoBehaviour {

    public float opacity = 1.0f;
    private Renderer rend;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        rend.material.SetFloat("_Alpha", opacity);
    }
}
