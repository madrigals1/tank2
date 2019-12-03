using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	float shootTimeDelta = 0f;
	Vector3 moveDirection = Vector3.zero, lastPos;
	CharacterController cc;
	float rotationAngle;
	int type = 0;									// 0 for first player, 1 for second player

	public Bullet Bullet, strongBullet;
	public Transform napalm;

	public float hp;
	public int weapon = 1;

	Transform top, shootPoint, body;

	void Start () {
		Find();
	}

	void Find(){
		cc = gameObject.GetComponent<CharacterController>();
		top = gameObject.transform.GetChild(0).GetChild(0).transform;
		body = gameObject.transform.GetChild(0).GetChild(1).transform;
		shootPoint = top.GetChild(0).transform;
	}

	public void Spawn(int type){
		this.type = type;
		lastPos = transform.position;
		if(type == 0) {
			hp = Values.Player.hp;
		}
	}
	
	void Update() {
		MoveTank();
		RotateTankTop();
		ChangeWeapon();
		ShootTank();
		HPCheck();
		NormalizeHeight();
	}

	void MoveTank() {
		if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= Values.Player.speed;

			float angle = Mathf.Atan2(moveDirection.z, moveDirection.x) * Mathf.Rad2Deg;

			cc.Move(moveDirection * Time.deltaTime);

			if(IsMoving()) body.rotation = Quaternion.Euler(0,90-angle,0);
		}
	}

	bool IsMoving () {
    	if(transform.position != lastPos) {
    		lastPos = transform.position;
    		return true;
    	} else {
    		return false;
    	}
    }

	void RotateTankTop() {
		Vector2 positionOnScreen = new Vector2 (top.position.x, top.position.z);
        Vector3 mouseOnScreen = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseOnScreen2D = new Vector2 (mouseOnScreen.x, mouseOnScreen.z);
         
        rotationAngle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen2D);
 
        top.rotation = Quaternion.Euler (new Vector3(0f,270-rotationAngle,0f));
	}

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

	void ChangeWeapon () {
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			weapon = 1;
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)){
			weapon = 2;
		}
	}

	void ShootTank() {
		shootTimeDelta += Time.deltaTime;
		if(weapon == 1) {
			if(Input.GetButton("Fire1") && shootTimeDelta > Values.Player.StrongBullet.cooldown){
				Bullet bulletIns = Instantiate(strongBullet, Values.bulletHolder) as Bullet;
				
				bulletIns.gameObject.name = "Player Strong Bullet";
				bulletIns.transform.position = shootPoint.position;
				bulletIns.rotationAngle = rotationAngle;
				bulletIns.Spawn(1);

				shootTimeDelta = 0;
			}
		}
		if(weapon == 2) {
			if(Input.GetButton("Fire1") && shootTimeDelta > Values.Player.Bullet.cooldown){
				Bullet bulletIns1 = Instantiate(Bullet, Values.bulletHolder) as Bullet;
				Bullet bulletIns2 = Instantiate(Bullet, Values.bulletHolder) as Bullet;
				
				bulletIns1.gameObject.name = "Player Bullet";
				bulletIns2.gameObject.name = "Player Bullet";

				bulletIns1.transform.position = shootPoint.GetChild(0).position;
				bulletIns2.transform.position = shootPoint.GetChild(1).position;

				bulletIns1.rotationAngle = rotationAngle;
				bulletIns2.rotationAngle = rotationAngle;

				bulletIns1.Spawn(0);
				bulletIns2.Spawn(0);				
				
				shootTimeDelta = 0;
			}
		}
	}

	void HPCheck () {
		if(hp <= 0) {
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
