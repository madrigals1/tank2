using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour {

	Object[] textures;
	public int look;
	Transform quad;

	void Start () {
		textures = Resources.LoadAll("Textures/Trees", typeof(Texture));
		look = Random.Range(0,4);
		quad = gameObject.transform.GetChild(0);
		quad.GetComponent<Renderer>().material.mainTexture = textures[look] as Texture;
	}
}
