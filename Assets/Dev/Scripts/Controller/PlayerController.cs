using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	float shootTimeDelta = 0f;
	Vector3 moveDirection = Vector3.zero;
	CharacterController cc;
	Vector3 lastPos;
	float topRotationAngle;

	public Transform weakBullet;
	public Transform strongBullet;
	public Transform napalm;

	public float hp;
	public int weapon = 1;

	Transform top;
	Transform shootPoint;
	Transform body;
	Transform bulletsHolder;

	void Start () {
		cc = gameObject.GetComponent<CharacterController>();
		top = gameObject.transform.GetChild(0).GetChild(0).transform;
		body = gameObject.transform.GetChild(0).GetChild(1).transform;
		shootPoint = top.GetChild(0).transform;
		bulletsHolder = GameObject.Find("Bullets").GetComponent<Transform>();
		lastPos = transform.position;
		hp = Values.Player.hp;
		SetCollisionIgnore();
	}

	void SetCollisionIgnore() {
		GameObject[] objects = GameObject.FindGameObjectsWithTag("IgnoreCollision");
		for(int i = 0; i < objects.Length; i++){
			if(Functions.ChildrenHasTag(objects[i], "IgnoreCollisionTanks"))
				Physics.IgnoreCollision(objects[i].GetComponent<Collider>(), gameObject.GetComponent<Collider>());
		}
	}
	
	void Update() {
		if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) MoveTank();
		RotateTankTop();
		ChangeWeapon();
		ShootTank();
		HPCheck();
		NormalizeHeight();
	}

	void MoveTank() {
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= Values.Player.speed;

		float angle = Mathf.Atan2(moveDirection.z, moveDirection.x) * Mathf.Rad2Deg;
		
		cc.Move(moveDirection * Time.deltaTime);
		
		if(IsMoving()) body.rotation = Quaternion.Euler(0,90-angle,0);
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
         
        topRotationAngle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen2D);
 
        top.rotation = Quaternion.Euler (new Vector3(0f,270-topRotationAngle,0f));
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
			if(Input.GetButton("Fire1") && shootTimeDelta > Values.StrongBullet.cooldown){
				Transform bulletIns = Instantiate(strongBullet) as Transform;
				
				bulletIns.gameObject.name = "StrongBulletGreen";
				bulletIns.position = shootPoint.position;
				bulletIns.GetComponent<BulletController>().rotationAngle = topRotationAngle;
				
				shootTimeDelta = 0;
			}
		}
		if(weapon == 2) {
			if(Input.GetButton("Fire1") && shootTimeDelta > Values.Bullet.cooldown){
				Transform bulletIns1 = Instantiate(weakBullet, bulletsHolder) as Transform;
				Transform bulletIns2 = Instantiate(weakBullet, bulletsHolder) as Transform;
				
				bulletIns1.gameObject.name = "WeakBullet";
				bulletIns2.gameObject.name = "WeakBullet";

				bulletIns1.position = shootPoint.GetChild(0).position;
				bulletIns2.position = shootPoint.GetChild(1).position;
				
				bulletIns1.GetComponent<BulletController>().rotationAngle = topRotationAngle;
				bulletIns2.GetComponent<BulletController>().rotationAngle = topRotationAngle;
				
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
