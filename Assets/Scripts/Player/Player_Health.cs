using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Health : MonoBehaviour
{
    public float health;
    public static Player_Health instance;
    void Start()
    {
        health = 100;
        instance = this;
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
