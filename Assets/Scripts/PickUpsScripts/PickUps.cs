using UnityEngine;
using System.Collections;

public class PickUps : MonoBehaviour {

    public float rotationSpeed = 1; // Rotates the pickup

    public Transform PlayerReference;
    public float pickUpDistance = 1;
    public bool forcePickUp = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    public void Update() 
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

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

    protected virtual void DisplayPickUpInformation()
    {
        Debug.Log("Press E to pickup");
    }

    protected virtual void PickUp()
    {
        Debug.Log("Picked up... sorta");    
    }

    protected virtual void Drop()
    {
        // If items needs to be dropped
        if (Input.GetKeyDown(KeyCode.F))
        {
            // If the player wants to drop the item and we want to let him choose too?
        }
    }
}
