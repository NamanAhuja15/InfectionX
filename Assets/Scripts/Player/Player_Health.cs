﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player_Health : MonoBehaviour
{
    public float health;
    private Animator anim;
    
    void Start()
    {
        health = 100;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (health >= 100)
            health = 100f;
        if (health <= 0)
        {
            health = 0f;
            Die();
        }
    }
    public void Die()
    {
        anim.SetTrigger("Die");
        SceneManager.LoadScene("GameOver");
        Destroy(gameObject, 1f);
    }
}
