using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	
	CharacterController cc;

	public Bullet strongBullet;
	
	Transform bulletsHolder, shootPoint;

	public float rotationAngle;

	public float hp = 0;
	public int dir = 0;

	float shootTimeDelta = 0f, dirTimeDelta = 0f;
	float shootCooldown = 0, dirCooldown = 0;
	int type = 0;
	public GameObject[] explosions;

	void Start () {
		Find();
	}

	void Find(){
		cc = gameObject.GetComponent<CharacterController>();
		bulletsHolder = GameObject.Find("Bullets").transform;
		shootPoint = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).transform;
	}

	public void Spawn(int type){
		this.type = type;
		if(type == 0){
			hp = Values.Enemies.Redtank.hp;
		}
		Rotate();
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
		if(shootCooldown == 0){
			shootCooldown = Random.Range(Values.Enemies.Redtank.StrongBullet.cooldownMin, Values.Enemies.Redtank.StrongBullet.cooldownMax);
		}
		if(dirCooldown == 0){
			dirCooldown = Random.Range(Values.Enemies.Redtank.Direction.cooldownMin, Values.Enemies.Redtank.Direction.cooldownMax);
		}
	}

	void TimeUpdater() {
		shootTimeDelta += Time.deltaTime;
		dirTimeDelta += Time.deltaTime;
	}

	void ShootAndRotate() {
		if(shootTimeDelta > shootCooldown){
			Shoot();
		}

		if(dirTimeDelta > dirCooldown){
			Rotate();
		}
	}

	void Shoot() {
		Bullet bulletIns = Instantiate(strongBullet, bulletsHolder) as Bullet;
		bulletIns.transform.position = shootPoint.position;
		bulletIns.rotationAngle = 270-rotationAngle;
		bulletIns.gameObject.name = "Redtank Strong Bullet";
		bulletIns.Spawn(2);
		shootTimeDelta = 0;
		shootCooldown = 0;
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
		dirCooldown = 0;
		gameObject.transform.rotation = Quaternion.Euler(0,rotationAngle,0);
	}

	void Move() {
		cc.Move(transform.forward * Time.deltaTime * Values.Enemies.Redtank.speed);
	}

	void HPCheck () {
		if(hp < 0){
			StartCoroutine(Destroyed());
		}
	}

	void NormalizeHeight () {
		Vector3 pos = gameObject.transform.position;
		if(pos.y != 0f) {
			gameObject.transform.position = new Vector3(pos.x, 0f, pos.z);
		}
	}

	IEnumerator Destroyed(){
		int num = Random.Range(0, explosions.Length);
		GameObject ins = Instantiate(explosions[num], Values.explosionHolder) as GameObject;
		ins.transform.position = transform.position;
		Destroy(gameObject);
		yield return new WaitForSeconds(3);
		Destroy(ins);
	}
}
