using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie_Health : MonoBehaviour
{
    public GameObject Health_bar;
    public float Health;
    private Animator animator;
    public GameObject[] DropObjects;

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
            gameObject.GetComponent<Zombie>().Dead = true;
            Health = 0f;
        }
        Health_bar.transform.localScale= new Vector3(Health / 100,Health_bar.transform.localScale.y,1);
        
    }
    public void Die()
    {
        GameObject drop = DropObjects[Random.Range(0, 2)];
        Instantiate(drop, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
