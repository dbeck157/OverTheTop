using UnityEngine;
using System.Collections;

public class NewPlayerFiring : MonoBehaviour
{
    public Transform currentWeapon;
    public bool isHoldingWeapon = false;
    public bool newCanFire = false;

    void Awake()
    {
        if(transform.childCount > 0)
        {
            currentWeapon = transform.GetChild(0);
            isHoldingWeapon = true;
            //Debug.Log("There is a child!");
        }
        else
        {
            isHoldingWeapon = false;
            //Debug.Log("There is no child!");
        }
    }

    void Update()
    {
        //if (Input.GetAxis("Fire1") > 0.1f)
        //{
        //    PrimaryFire();
        //}

        if (transform.childCount > 0)
        {
            currentWeapon = transform.GetChild(0);
            isHoldingWeapon = true;
            Debug.Log("There is a child!");
        }
        else
        {
            currentWeapon = null;
            isHoldingWeapon = false;
            Debug.Log("There is no child!");
        }

        if (currentWeapon != null)
        {
            if (Input.GetMouseButton(0))
            {
                //newCanFire = transform.GetChild(0).GetComponent<NewWeapon>().canFire;
                transform.GetComponentInChildren<NewWeapon>().canFire = true;
                //Debug.Log(newCanFire);
            }
            //Fire Weapon that is attached
            Debug.Log("You have a weapon!");
        }
        else
        {
            //Fire Weapon that is attached
            Debug.Log("You DO NOT have a weapon!");
        }

        
    }
}