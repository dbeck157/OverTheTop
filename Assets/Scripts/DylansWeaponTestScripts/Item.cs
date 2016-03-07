using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    GameObject player;
    public Transform weaponHolder;
    public float pickUpRadius = 5f;
    public float distance = 0;
    public bool canFire = false;

	// Use this for initialization
	public void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        weaponHolder = transform.parent.parent;
	}
	
	// Update is called once per frame
	public void Update () {

        distance = Vector3.Distance(player.gameObject.transform.position, weaponHolder.position);
        //Debug.Log(distance);
	    if(Input.GetKeyDown(KeyCode.E) && distance < pickUpRadius)
        {
            PickUp();
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }
	}

    public void PickUp()
    {
        weaponHolder.parent = player.transform.GetChild(0);
        weaponHolder.transform.localPosition = new Vector3(0, 0, 0);
        weaponHolder.transform.rotation = player.transform.GetChild(0).rotation;
    }

    public void Drop()
    {
        canFire = false;
        weaponHolder.parent = null;
    }
}
