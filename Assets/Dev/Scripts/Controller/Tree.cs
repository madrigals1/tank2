using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

	Object[] textures;
	public int look;
	Transform quad;

	void Start () {
		look = Random.Range(0,4);
		quad = transform.GetChild(0);
		quad.GetComponent<Renderer>().material.mainTexture = Values.Trees.textures[look] as Texture;
	}
}
