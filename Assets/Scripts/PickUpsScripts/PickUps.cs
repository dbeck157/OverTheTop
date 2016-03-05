using UnityEngine;
using System.Collections;

public class PickUps : MonoBehaviour {

    public Transform PlayerReference;
    public float pickUpDistance = 1;
    public bool forcePickUp = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (CanPickUp())// If player is close display pickup key to pick up
        {
            DisplayPickUpInformation(); // Displays pickup information
            if(Input.GetKeyDown(KeyCode.E) || forcePickUp) // if the player presses the key or the item is a force pick up pick it up
            {
                PickUp();
            }
        }
    }

    bool CanPickUp() // Checks the distance between pickup and player
    {
        float distance = Vector3.Distance(PlayerReference.position, transform.position);

        return distance < pickUpDistance;
    }

    void DisplayPickUpInformation()
    {
        Debug.Log("Press E to pickup");
    }

    void PickUp()
    {
        Debug.Log("Picked up... sorta");    
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
