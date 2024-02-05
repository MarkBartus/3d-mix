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
    public Transform attackpoint;
    public float attackrange = 0.5f;
    public LayerMask enemyLayers;
  
    //bool isPunching;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        //isPunching = false;
        
    }


// Update is called once per frame
void Update()
    {
        anim.SetBool("idle", true);
        anim.SetBool("run", false);
        anim.SetBool("walk back", false);
        anim.SetBool("jump", false);
        anim.SetBool("RPunch", false);

        if (isOnGround == false)
        {
            anim.SetBool("fall", true);           
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Attack();
            //isPunching = true;

        }


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
   

        //DoPunch();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
    
    /*void DoPunch ()
    {
        if (isPunching == true)
        {
            anim.SetBool("RPunch", true);
            anim.SetBool("idle", false);
            anim.SetBool("run", false);


            if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("RPunch"))
            {
                isPunching = false;
            }
        }      
    }
    */
    void Attack()
    {
        anim.SetTrigger("Attack");

        Collider[] hitEnemies =Physics.OverlapSphere(attackpoint.position, attackrange, enemyLayers);

        foreach(Collider enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
            return;

        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }

}

