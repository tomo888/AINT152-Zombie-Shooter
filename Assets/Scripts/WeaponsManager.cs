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
    Transform current = null;
    public static bool pistol = true;
    public static bool SMG = false;
    public static bool rifle = false;

    void Start()
    {
        // select the first weapon by default
        ChangeWeapon(0);
    }

    // this sets the weapon using the provided index
    // it will switch off all the other child gameobjects of this one
    public void ChangeWeapon(int index)
    {
        // loop through all the child gameobjects
        // get a cound of how many children using transform.childCount
        for (int i = 0; i < transform.childCount; i++)
        {
            // if this child gameobject is the same one as the index, switch it on
            if (i == index)
            {
                // set the current weapon as this child
                current = transform.GetChild(index);

                // switch this child gameobject on, ready for shooting
                // use gameobject.setactive to switch it on
                current.gameObject.SetActive(true);
            }
            else // if this child gameobject is not the same as the index, switch it off
            {
                // use gameobject.setactive to switch it off
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // send the event if the key was pressed
            ChangeWeapon(0);
            pistol = true;
            SMG = false;
            rifle = false;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // send the event if the key was pressed
            ChangeWeapon(1);
            pistol = false;
            SMG = true;
            rifle = false;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // send the event if the key was pressed
            ChangeWeapon(2);
            pistol = false;
            SMG = false;
            rifle = true;
        }
    }

    // this sends a message to the selected weapon to fire
    // make sure weapons have a "Fire" method to use
    public void Fire()
    {
        // send a message to the current weapon to fire
        // note the last parameter "SendMessageOptions.DontRequireReceiver"
        // this will stop any errors if the thing we are messaging doesn't have a "TakeDamage" method with an integer
        current.SendMessage("Fire", SendMessageOptions.DontRequireReceiver);
    }
}
