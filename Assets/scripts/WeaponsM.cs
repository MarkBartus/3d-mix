using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsM : MonoBehaviour
{

    public GameObject weapon;


    public void EnableWeaponCollider(int isEnable)
    {
        var col = weapon.GetComponent<Collider>();

        if(col != null)
        {
            if(isEnable == 1)
            {
                col.enabled = true;
            }
            else
            {
                col.enabled = false;
            }
             
        }
    }
}
