using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour {

	int[,] level = new int[,]{
		{0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,1,0,1,0,1,0,1,0,1,0,1,0},
		{0,1,2,1,0,1,3,1,0,1,2,1,0},
		{0,1,0,1,0,1,0,1,0,1,0,1,0},
		{0,1,0,1,0,0,0,0,0,1,0,1,0},
		{0,0,0,0,0,1,0,1,0,0,0,0,0},
		{3,0,1,1,0,0,0,0,0,1,1,0,3},
		{4,0,0,0,0,1,0,1,0,0,0,0,4},
		{4,1,0,1,0,1,0,1,0,1,0,1,4},
		{4,1,0,1,0,1,0,1,0,1,0,1,4},
		{4,1,2,1,0,0,0,0,0,1,2,1,4},
		{4,1,0,1,0,1,1,1,0,1,0,1,4},
		{4,4,4,0,0,1,0,1,0,0,4,4,4}
	};
	
	public GameObject brown_brick;
	public GameObject steel_brick;
	public GameObject water;
	public GameObject tree;

	Transform tankHolder;

	void Start () {
		tankHolder = GameObject.Find("Tanks").transform;
		for(int i = 0; i < 13; i++){
			for(int j = 0; j < 13; j++){
				if(level[i,j] == 1){
					GameObject ins = Instantiate(brown_brick, gameObject.transform) as GameObject;
					ins.transform.localPosition = new Vector3(j,0,-i);
					ins.gameObject.name = "Brown_Brick";
				}
				if(level[i,j] == 2){
					GameObject ins = Instantiate(water, gameObject.transform) as GameObject;
					ins.transform.localPosition = new Vector3(j,0,-i);
					ins.gameObject.name = "Water";
				}
				if(level[i,j] == 3){
					GameObject ins = Instantiate(steel_brick, gameObject.transform) as GameObject;
					ins.transform.localPosition = new Vector3(j,0,-i);
					ins.gameObject.name = "Steel_Brick";
				}
				if(level[i,j] == 4){
					GameObject ins = Instantiate(tree, gameObject.transform) as GameObject;
					ins.transform.localPosition = new Vector3(j,0.5f,-i);
					ins.gameObject.name = "Tree";
				}
			}
		}
	}
}