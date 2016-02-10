using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent (typeof(Camera))]
public class CameraPost : MonoBehaviour {

	public Shader shader;
	private Material material;

	// Creates a private material used to the effect
	void Awake ()
	{
		material = new Material( shader );
	}

	// Postprocess the image
	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit (source, destination, material);
	}
}