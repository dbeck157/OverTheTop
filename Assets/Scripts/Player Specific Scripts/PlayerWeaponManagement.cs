using UnityEngine;
using System.Collections;

public class PlayerWeaponManagement : MonoBehaviour {

    GameObject activeWeapon;
    Transform weaponClone;
    public Transform weaponPosition;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeWeapon(GameObject newWeapon)
    {
        if(weaponClone != null)
        {
            Transform temp = weaponClone;
            weaponClone = null;
            Destroy(temp.gameObject);
        }
        //if(activeWeapon != newWeapon)
        {
            activeWeapon = newWeapon;
        }
        EquipActiveWeapon();
        // If same add ammo?
    }
    
    void EquipActiveWeapon()
    {
        weaponClone = Instantiate(activeWeapon.transform, weaponPosition.position, weaponPosition.rotation) as Transform;
        weaponClone.SetParent(weaponPosition);
    }
}
