using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{

    public int Health;
    public int attack;

    public Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int amount)
    {
        Health -= amount;

        if (Health <= 0)
        {
            //player is dead 
            //death animation plays
            anim.SetBool("IsDead", true);
            Destroy(this.gameObject);
            //game over screen
        }
    }

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<health>();
        if(atm != null)
        {
            atm.TakeDamage(attack);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("barrier"))
        {
            Health--;
            if (Health <= 0)
            {
                //player is dead 
                //death animation plays
                anim.SetBool("IsDead", true);
                Destroy(this.gameObject);
                //game over screen
            }
        }
    }


}
