using UnityEngine;
using System.Collections;

public class LightEffects : MonoBehaviour {

    public float intensityMin = 0.1f;
    public float intensityMax = 0.5f;
    public float flickerSpeed = 1.0f;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Flicker", 0, flickerSpeed);
    }
	
	// Update is called once per frame
	void Update () {

    }

    void Flicker()
    {
        GetComponent<Light>().intensity = Random.Range(intensityMin, intensityMax);
    }

}
