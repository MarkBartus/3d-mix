using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public Transform player;
    private Rigidbody rb;
    private Animator anim;
    private bool inRange;
    private float distance;
    bool Attack;
    bool movement;
    public float AggroRange = 2f;
    public float InRange = 2f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack = range(Attack);
    }

    bool range(bool Attack)
    {
        float seperation = Vector3.Distance(this.transform.position, player.transform.position);
        print(seperation);
        if (seperation <= AggroRange)
        {
            Attack = true;
            anim.SetBool("Attack", true);
        }
        else
        {
            Attack = false;           
            anim.SetBool("Attack", false);
        }
        return Attack;
    }
}
