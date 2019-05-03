using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	Rigidbody rb;
	public float rotationAngle = 0;
	float damage = 0;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
		gameObject.transform.rotation = Quaternion.Euler(90,270-rotationAngle,0);
		CalculateDamage();
		SetCollisionIgnore();
	}

	void CalculateDamage () {
		if(gameObject.name == "StrongBulletRed") damage = Values.Enemy.damage;
		if(gameObject.name == "StrongBulletGreen") damage = Values.StrongBullet.damage;
		if(gameObject.name == "WeakBullet") damage = Values.Bullet.damage;
	}

	void SetCollisionIgnore() {
		GameObject[] objects = GameObject.FindGameObjectsWithTag("IgnoreCollision");
		for(int i = 0; i < objects.Length; i++){
			Physics.IgnoreCollision(objects[i].GetComponent<Collider>(), gameObject.GetComponent<Collider>());
		}
	}

	void OnCollisionEnter (Collision col) {
		if(col.gameObject.tag == "Wall") {
			Destroy(gameObject);
			if(Functions.ChildrenHasTag(col.gameObject, "Brick")) {
				col.gameObject.GetComponent<BrickController>().hp -= damage;
				col.gameObject.GetComponent<BrickController>().hpChanged = true;
			}
		}
		
		if(col.gameObject.tag == "Enemy") {
			if(Functions.ChildrenHasTag(gameObject, "Enemy")){
				Physics.IgnoreCollision(col.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
			} else {
				Destroy(gameObject);				
				col.gameObject.transform.parent.GetComponent<EnemyController>().hp -= damage;
			}
		}

		if(col.gameObject.tag == "Player"){
			if(Functions.ChildrenHasTag(gameObject, "Player")){
				Physics.IgnoreCollision(col.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
			} else {
				Destroy(gameObject);
				col.gameObject.transform.parent.GetComponent<PlayerController>().hp -= damage;
			}
		}

		if(col.gameObject.tag == "Bullet") {
			Destroy(gameObject);
			Destroy(col.gameObject);
		}
	}

	void Update () {
		rb.velocity = transform.up * Values.Bullet.speed;
	}
}
