using UnityEngine;
using System.Collections;

public class PickUps : MonoBehaviour {

    public Transform PlayerReference;
    public float pickUpDistance = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        PickUp();
	}

    bool CanPickUp()
    {
        float distance = Vector3.Distance(PlayerReference.position, transform.position);

        return distance < pickUpDistance;
    }

    void PickUp()
    {
        // get distance between the pickup and the player

        if (CanPickUp())// If player is close display pickup key to pick up
        {
            Debug.Log("Press E To Pickup");
            // display pick up option
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Picked up... sorta");
                // If they press the key pick it up
            }
        }
        
    }

    void Drop()
    {
        // If items needs to be dropped
        if (Input.GetKeyDown(KeyCode.D))
        {
            // If the player wants to drop the item?
        }
    }


}
