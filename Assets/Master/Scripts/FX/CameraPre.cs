using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent (typeof(Camera))]
public class CameraPre : MonoBehaviour {

	public Shader shader;

	void Awake ()
	{
		GetComponent<Camera> ().SetReplacementShader (shader,null);
	}

}
