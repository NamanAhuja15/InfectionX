using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Health : MonoBehaviour
{
    public float health;
 
    
    void Start()
    {
        health = 100;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

   // Update is called once per frame
    void Update()
    {
        
    }
}
