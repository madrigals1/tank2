using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public float hp = 100;
    public bool hpChanged = false;
    public int type = 0;                // 0 for Brown Brick, 1 for Steel Brick
    Transform quad;

    void Start()
    {
        quad = gameObject.transform.GetChild(0);
    }

    public void Spawn(int type)
    {
        this.type = type;
        if (type == 0)
        {
            hp = 100;
        }
        if (type == 1)
        {
            hp = 1000;
        }
    }

    void Update()
    {
        if (hpChanged)
        {
            SetTexture();
        }
    }

    void SetTexture()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            int x = 0;
            switch (type)
            {
                case 0:
                    x = (int)(hp / Values.Brick.Brown.hpstep);
                    if (x == 5) x = 4;
                    Debug.Log(x);
                    Debug.Log(Values.Brick.Brown.textures.Length);
                    Debug.Log(Values.Brick.Brown.textures[x]);
                    Debug.Log(quad.GetComponent<Renderer>());
                    quad.GetComponent<Renderer>().material.mainTexture = Values.Brick.Brown.textures[x];
                    break;
                case 1:
                    x = (int)(hp / Values.Brick.Steel.hpstep);
                    if (x == 5) x = 4;
                    quad.GetComponent<Renderer>().material.mainTexture = Values.Brick.Steel.textures[x];
                    break;
            }
        }
        hpChanged = false;
    }
}
