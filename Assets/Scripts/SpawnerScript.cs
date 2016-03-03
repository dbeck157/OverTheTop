using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerScript : MonoBehaviour {

    public GameObject enemy;
    public List<GameObject> spawners = new List<GameObject>();

	// Use this for initialization
	void Start () {
        Invoke("Spawn", 0);
        spawners.AddRange(GameObject.FindGameObjectsWithTag("Spawner"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Spawn()
    {
        GameObject clone = Instantiate(enemy, spawners[Random.Range(0, spawners.Count)].transform.position, transform.rotation) as GameObject;
        Invoke("Spawn", 1f);
    }
}
