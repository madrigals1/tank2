using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject brown_brick, steel_brick, water, tree;
    public int level = 0;
    void Start()
    {
        Values.bulletHolder = GameObject.Find("Bullets").transform;
        Values.tankHolder = GameObject.Find("Tanks").transform;
        Values.explosionHolder = GameObject.Find("Explosions").transform;
        Values.blockHolder = GameObject.Find("Blocks").transform;
        for (int i = 0; i < 5; i++)
        {
            Values.Brick.Brown.textures[i] = Resources.Load(
                "Textures/Bricks/red_" + ((i + 1) * Values.Brick.Brown.hpstep),
                typeof(Texture)
            ) as Texture;

            Values.Brick.Steel.textures[i] = Resources.Load(
                "Textures/Bricks/silver_" + ((i + 1) * Values.Brick.Steel.hpstep),
                typeof(Texture)
            ) as Texture;
        }
        Values.Trees.textures = Resources.LoadAll("Textures/Trees", typeof(Texture));
        SetCollisionIgnore();
        SpawnLevel();
    }

    void SetCollisionIgnore()
    {
        /*
            Layer 0 : Default
            Layer 1 : TransparetnFX
            Layer 2 : Ignore Raycast
            Layer 3 :
            Layer 4 : Water
            Layer 5 : UI
            Layer 6 :
            Layer 7 :
            Layer 8 : PostProcessing
            Layer 9 : Player
            Layer 10 : Enemy
            Layer 11 : Player Bullet
            Layer 12 : Enemy Bullet
            Layer 13 : Tree
            Layer 14 : Brick
        */

        Physics.IgnoreLayerCollision(9, 11);
        Physics.IgnoreLayerCollision(10, 12);
        Physics.IgnoreLayerCollision(9, 13);
        Physics.IgnoreLayerCollision(10, 13);
        Physics.IgnoreLayerCollision(11, 13);
        Physics.IgnoreLayerCollision(11, 4);
        Physics.IgnoreLayerCollision(12, 13);
        Physics.IgnoreLayerCollision(12, 4);
    }

    void SpawnLevel()
    {
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                if (Values.level[level, i, j] == 1)
                {
                    GameObject ins = Instantiate(brown_brick, Values.blockHolder) as GameObject;
                    ins.transform.localPosition = new Vector3(j, 0, -i);
                    ins.gameObject.name = "Brown Brick";
                    ins.GetComponent<Brick>().Spawn(0);
                }
                if (Values.level[level, i, j] == 2)
                {
                    GameObject ins = Instantiate(water, Values.blockHolder) as GameObject;
                    ins.transform.localPosition = new Vector3(j, 0, -i);
                    ins.gameObject.name = "Water";
                }
                if (Values.level[level, i, j] == 3)
                {
                    GameObject ins = Instantiate(steel_brick, Values.blockHolder) as GameObject;
                    ins.transform.localPosition = new Vector3(j, 0, -i);
                    ins.gameObject.name = "Steel Brick";
                    ins.GetComponent<Brick>().Spawn(1);
                }
                if (Values.level[level, i, j] == 4)
                {
                    GameObject ins = Instantiate(tree, Values.blockHolder) as GameObject;
                    ins.transform.localPosition = new Vector3(j, 0.5f, -i);
                    ins.gameObject.name = "Tree";
                }
            }
        }
    }
}
