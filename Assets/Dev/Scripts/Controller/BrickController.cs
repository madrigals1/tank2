using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

	public float hp = 100;
	public bool hpChanged = false;
	Transform quad;

	void Start () {
		quad = gameObject.transform.GetChild(0);
	}

	void Update () {
		if (hpChanged) {
			if(gameObject.name == "Brown_Brick") {
				if(hp > 80) {
					Texture spr = Resources.Load("Textures/Bricks/brick_brown_100", typeof(Texture)) as Texture;
					quad.GetComponent<Renderer>().material.mainTexture = spr;
				}
				if(hp > 60 && hp <= 80) {
					Texture spr = Resources.Load("Textures/Bricks/brick_brown_80", typeof(Texture)) as Texture;
					quad.GetComponent<Renderer>().material.mainTexture = spr;
				}
				if(hp > 40 && hp <= 60) {
					Texture spr = Resources.Load("Textures/Bricks/brick_brown_60", typeof(Texture)) as Texture;
					quad.GetComponent<Renderer>().material.mainTexture = spr;
				}
				if(hp > 20 && hp <= 40) {
					Texture spr = Resources.Load("Textures/Bricks/brick_brown_40", typeof(Texture)) as Texture;
					quad.GetComponent<Renderer>().material.mainTexture = spr;
				}
				if(hp > 0 && hp <= 20) {
					Texture spr = Resources.Load("Textures/Bricks/brick_brown_20", typeof(Texture)) as Texture;
					quad.GetComponent<Renderer>().material.mainTexture = spr;
				}
				if(hp <= 0) {
					Destroy(gameObject);
				}
			}
			if(gameObject.name == "Steel_Brick") {
				if(hp > 800) {
					Texture spr = Resources.Load("Textures/Bricks/brick_steel_100", typeof(Texture)) as Texture;
					quad.GetComponent<Renderer>().material.mainTexture = spr;
				}
				if(hp > 600 && hp <= 800) {
					Texture spr = Resources.Load("Textures/Bricks/brick_steel_80", typeof(Texture)) as Texture;
					quad.GetComponent<Renderer>().material.mainTexture = spr;
				}
				if(hp > 400 && hp <= 600) {
					Texture spr = Resources.Load("Textures/Bricks/brick_steel_60", typeof(Texture)) as Texture;
					quad.GetComponent<Renderer>().material.mainTexture = spr;
				}
				if(hp > 200 && hp <= 400) {
					Texture spr = Resources.Load("Textures/Bricks/brick_steel_40", typeof(Texture)) as Texture;
					quad.GetComponent<Renderer>().material.mainTexture = spr;
				}
				if(hp > 0 && hp <= 200) {
					Texture spr = Resources.Load("Textures/Bricks/brick_steel_20", typeof(Texture)) as Texture;
					quad.GetComponent<Renderer>().material.mainTexture = spr;
				}
				if(hp <= 0) {
					Destroy(gameObject);
				}
			}
			hpChanged = false;
		}
	}
}
