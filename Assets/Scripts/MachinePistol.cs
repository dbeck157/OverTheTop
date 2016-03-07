using UnityEngine;
using System.Collections;

public class MachinePistol : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RemoveCurrentWeapon()
    {
        Destroy(gameObject);
    }
}
