using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{

    public bool isOnGround = true;
    public float jumpforce = 5;
    public float ro_speed;
    public Transform playerTrans;
    private float Wvelocity = 4;
    private float Svelocity = -2;    
    private Rigidbody rb;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("idle", true);
        anim.SetBool("run", false);
        anim.SetBool("walk back", false);
        anim.SetBool("jump", false);

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("idle", false);
            anim.SetBool("run", true);
            transform.position += transform.forward * Wvelocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("idle", false);          
            anim.SetBool("walk back", true);
            transform.position += transform.forward * Svelocity * Time.deltaTime;

        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            anim.SetBool("idle", false);
            anim.SetBool("jump", true);
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isOnGround = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

}

