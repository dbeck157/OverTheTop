using UnityEngine;
using System.Collections;

public class WeaponPickUp : PickUps {

    enum WeaponType { NormalWeapon, GrenadeLauncher, Sword, MachinePistol}
    WeaponType weaponType = WeaponType.MachinePistol;

    //public float rateOfFire;
    //public float weaponPower;
    //public float weaponRange;
    public GameObject pickUpWeaponType;


	// Use this for initialization
	void Start () {
        switch (weaponType)
        {
            case WeaponType.NormalWeapon:
                break;
            case WeaponType.GrenadeLauncher:
                break;
            case WeaponType.Sword:
                break;
            case WeaponType.MachinePistol:
                //pickUpWeaponType = GameObject.Find("MachinePistol");
                break;
            default:
                Debug.Log("Someone broke the weapon!");
                break;
        }
	}
	
	// Update is called once per frame
	new public void Update () {
        base.Update();
	}

    protected override void PickUp() // Inherits from PickUps
    {
        // Send pick up information to player here
        base.PlayerReference.GetComponent<PlayerWeaponManagement>().ChangeWeapon(pickUpWeaponType);
        Debug.Log("Picked up a " + weaponType.ToString());
    }
}
