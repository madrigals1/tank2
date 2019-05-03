using UnityEngine;

public static class Functions {
	public static bool ChildrenHasTag (GameObject go, string tag) {
		Transform t = go.transform;
		int amount = t.childCount;
		bool has = false;
		for(int i = 0; i < amount; i++){
			if(t.GetChild(i).gameObject.tag == tag){
				has = true;
			}
		}

		return has;
	}
}
