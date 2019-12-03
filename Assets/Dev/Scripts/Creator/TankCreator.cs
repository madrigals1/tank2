using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCreator : MonoBehaviour {

	int[,] level = new int[,]{
		{2,0,0,0,0,0,2,0,0,0,0,0,2},
		{0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,1,0,0,0,0,0,0,0,0}
	};

	public GameObject player, enemy;

	void Start () {
		for(int i = 0; i < 13; i++){
			for(int j = 0; j < 13; j++){
				if(level[i,j] == 1){
					GameObject ins = Instantiate(player, gameObject.transform) as GameObject;
					ins.transform.localPosition = new Vector3(j,0,-i);
					ins.gameObject.name = "Player";
					ins.GetComponent<Player>().Spawn(0);
				}
				if(level[i,j] == 2){
					GameObject ins = Instantiate(enemy, gameObject.transform) as GameObject;
					ins.transform.localPosition = new Vector3(j,0,-i);
					ins.gameObject.name = "Enemy";
					ins.GetComponent<Enemy>().Spawn(0);
				}
			}
		}
	}
}
