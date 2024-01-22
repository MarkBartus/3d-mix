using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform tp2;

    private void OnTriggerEnter(Collider col)
    {
        Player.transform.position = tp2.transform.position;
        
    }
}
