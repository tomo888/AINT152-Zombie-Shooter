using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// this component will select a child gameobject by its index (its order in the hierarchy)
// the other child gameobjects will be switched off
// the top gameobject will be index 0, next is 1 etc
// NOTE: only put weapon gameobjects as children of this one!
public class WeaponsManager : MonoBehaviour 
{
	// current stores the currently active weapon (the child gameobject switched on)
    public int weaponChoice = 0;

	void Start() 
	{
        ChangeWeapon(0);
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponChoice = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >=2)
        {
            weaponChoice = 1;
        }
    }

    // this sets the weapon using the provided index
    // it will switch off all the other child gameobjects of this one
    void ChangeWeapon (int index) 
	{
        int i = 0;
		foreach (Transform weapon in transform)
        {
            if (i == weaponChoice)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
	}
	
	// this sends a message to the selected weapon to fire
	// make sure weapons have a "Fire" method to use
	public void Fire() 
	{
		// send a message to the current weapon to fire
		// note the last parameter "SendMessageOptions.DontRequireReceiver"
		// this will stop any errors if the thing we are messaging doesn't have a "TakeDamage" method with an integer
		weaponChoice.SendMessage("Fire", SendMessageOptions.DontRequireReceiver);
	}
}
