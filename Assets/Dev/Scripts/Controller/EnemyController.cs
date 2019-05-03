using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	
	CharacterController cc;

	public Transform strongBullet;
	
	Transform body;
	Transform bulletsHolder;
	Transform shootPoint;

	public float rotationAngle;

	public float hp = 0;
	public int dir = 0;

	float shootTimeDelta = 0f;
	float dirTimeDelta = 0f;

	public bool shootCooldownSet = false;
	public bool dirCooldownSet = false;

	void Start () {
		body = gameObject.transform;
		cc = gameObject.GetComponent<CharacterController>();
		bulletsHolder = GameObject.Find("Bullets").transform;
		shootPoint = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).transform;
		hp = Values.Enemy.hp;
		dir = (int) Random.Range(0,5);
		Rotate();
		SetCollisionIgnore();
	}

	void SetCollisionIgnore() {
		GameObject[] objects = GameObject.FindGameObjectsWithTag("IgnoreCollision");
		for(int i = 0; i < objects.Length; i++){
			if(Functions.ChildrenHasTag(objects[i], "IgnoreCollisionTanks"))
				Physics.IgnoreCollision(objects[i].GetComponent<Collider>(), gameObject.GetComponent<Collider>());
		}
	}

	void Update () {
		MoveAndShoot();
		HPCheck();
		NormalizeHeight();
	}

	void MoveAndShoot () {
		SetCoolDown();
		TimeUpdater();
		ShootAndRotate();
		Move();
	}

	void SetCoolDown() {
		if(!shootCooldownSet){
			Values.Enemy.shootCooldown = Random.Range(Values.Enemy.shootCooldownMin, Values.Enemy.shootCooldownMax);
			shootCooldownSet = true;
		}
		if(!dirCooldownSet){
			Values.Enemy.dirCooldown = Random.Range(Values.Enemy.dirCooldownMin, Values.Enemy.dirCooldownMax);
			dirCooldownSet = true;
		}
	}

	void TimeUpdater() {
		shootTimeDelta += Time.deltaTime;
		dirTimeDelta += Time.deltaTime;
	}

	void ShootAndRotate() {
		if(shootTimeDelta > Values.Enemy.shootCooldown){
			Shoot();
		}

		if(dirTimeDelta > Values.Enemy.dirCooldown){
			Rotate();
		}
	}

	void Shoot() {
		Transform bulletIns = Instantiate(strongBullet, bulletsHolder) as Transform;
		bulletIns.position = shootPoint.position;
		bulletIns.GetComponent<BulletController>().rotationAngle = 270-rotationAngle;
		bulletIns.gameObject.name = "StrongBulletRed";
		shootTimeDelta = 0;
		shootCooldownSet = false;
	}

	void Rotate() {
		dir = (int) Random.Range(0,5);
		switch(dir) {
			case 0: break;
			case 1: rotationAngle = 0; break;
			case 2: rotationAngle = 90; break;
			case 3: rotationAngle = 180; break;
			case 4: rotationAngle = 270; break;
		}
		dirTimeDelta = 0;
		dirCooldownSet = false;

		gameObject.transform.rotation = Quaternion.Euler(0,rotationAngle,0);
	}

	void Move() {
		cc.Move(transform.forward * Time.deltaTime * Values.Enemy.speed);
	}

	void HPCheck () {
		if(hp < 0){
			Destroy(gameObject);
		}
	}

	void NormalizeHeight () {
		Vector3 pos = gameObject.transform.position;
		if(pos.y != 0f) {
			gameObject.transform.position = new Vector3(pos.x, 0f, pos.z);
		}
	}
}
