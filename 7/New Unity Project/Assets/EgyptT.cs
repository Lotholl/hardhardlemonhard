using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EgyptT : BricksT
{
	public Texture Egypt;
	// Use this for initialization
	void Start()
	{
		meshRenderer = GetComponent<MeshRenderer>();
	}
	public void obCAT()
	{
		meshRenderer.material.SetTexture("_MainTex", Egypt);
	}

	public void setEgypt()
    {
		check = "Egypt texture";
	}
}
