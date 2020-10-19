using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksT : DecSize
{
	public string check = null;
	public MeshRenderer meshRenderer;
	public Texture Bricks;
	// Use this for initialization
	void Start()
	{
		meshRenderer = GetComponent<MeshRenderer>();
	}
	public void CAT()
	{
		meshRenderer.material.SetTexture("_MainTex", Bricks);
	}

	public void setBricks()
    {
		check = "Bricks texture";
	}
}
