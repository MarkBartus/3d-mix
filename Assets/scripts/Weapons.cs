using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    public health atm;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("target"))
        {
            other.GetComponent<health>().TakeDamage(atm.attack);
        }
    }
}
