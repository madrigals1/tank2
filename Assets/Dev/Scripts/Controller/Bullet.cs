﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	Rigidbody rb;
	public float rotationAngle = 0;
	float damage = 0, speed = 0;
	public int type = 0;				// 0 for regular bullet, 1 for strong player bullet, 2 for strong enemy bullet
	public Transform bulletExplosion, brownExplosion;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
	}

	public void Spawn(int type){
		this.type = type;
		CalculateDamageAndSpeed();
		gameObject.transform.rotation = Quaternion.Euler(90,270-rotationAngle,0);
	}

	void CalculateDamageAndSpeed() {
		switch(type){
			case 0:
				damage = Values.Player.Bullet.damage;
				speed = Values.Player.Bullet.speed;
			break;
			case 1:
				damage = Values.Player.StrongBullet.damage;
				speed = Values.Player.StrongBullet.speed;
			break;
			case 2:
				damage = Values.Enemies.Redtank.StrongBullet.damage;
				speed = Values.Enemies.Redtank.StrongBullet.speed;
			break;
		}
	}

	void OnCollisionEnter (Collision col) {
		if(col.gameObject.tag == "Wall") {
			DestroyBullet();
		}

		if(col.gameObject.tag == "Brick"){
			DestroyBullet();
			col.gameObject.GetComponent<Brick>().hp -= damage;
			col.gameObject.GetComponent<Brick>().hpChanged = true;
		}
		
		if(col.gameObject.tag == "Enemy") {
			DestroyBullet();				
			col.gameObject.transform.parent.GetComponent<Enemy>().hp -= damage;
		}

		if(col.gameObject.tag == "Player"){
			DestroyBullet();
			col.gameObject.transform.parent.GetComponent<Player>().hp -= damage;
			
		}

		if(col.gameObject.tag == "Bullet") {
			DestroyBullet();
			Destroy(col.gameObject);
		}
	}

	void DestroyBullet(){
		Destroy(gameObject);
		if(type == 1 || type == 2){
			StartCoroutine(DestroyByTime(bulletExplosion));
		}
		if(type == 0){
			StartCoroutine(DestroyByTime(brownExplosion));
		}
	}

	IEnumerator DestroyByTime(Transform go){
		Transform ins = Instantiate(go, Values.explosionHolder) as Transform;
		ins.position = transform.GetChild(0).position;
		yield return new WaitForSeconds(0.5f);
		Destroy(ins.gameObject);
	}

	void Update () {
		rb.velocity = transform.up * speed;
	}
}