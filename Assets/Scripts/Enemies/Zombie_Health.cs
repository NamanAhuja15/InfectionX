using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie_Health : MonoBehaviour
{
    public Sprite Health_bar;
    public float Health;
    private Animator animator;

    void Start()
    {
        Health = 100f;
        animator = GetComponent<Animator>();
    }
    public void TakeDmg(float dmg)
    {
        Health -= dmg;
    }

    // Update is called once per frame
    void Update()
    {
        if(Health<=0)
        {
            animator.SetTrigger("Dead");
            gameObject.GetComponent<Zombie>().dead = true;
        }
        
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }
}
