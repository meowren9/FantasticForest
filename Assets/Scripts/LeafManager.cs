using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafManager : MonoBehaviour {
    
    public GameObject leaf;
    public float spawnTime = 1f;

    public float py;

    public float px1, px2, pz1, pz2;

    void Start()
    {
        //InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    public void StartFalling()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    public void StopFalling()
    {
        CancelInvoke("Spawn");
    }

    void Spawn()
    {

        float px = Random.Range(px1, px2);
        float pz = Random.Range(pz1, pz2);
        //float ry = Random.Range(0, 360);

        Vector3 position = new Vector3(px, 0f, pz);
        Quaternion rotation = new Quaternion(0f, 180f, 0f, 0f);

        Instantiate(leaf, position, rotation);
        //Instantiate(leaf, position, );
    }
}
