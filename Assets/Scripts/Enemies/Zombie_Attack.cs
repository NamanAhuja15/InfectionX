using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Attack : MonoBehaviour
{
    private Zombie zombie_script;
    private GameObject zombie;
    private bool  attack, detect,dead;
    private float timer;
    public float recoil;
    public GameObject gunpoint,bullet;
    void Start()
    {
        zombie_script = gameObject.GetComponentInParent<Zombie>();
        zombie = zombie_script.gameObject;
    }

        public void OnTriggerStay2D(Collider2D collider)
    {
        if (!dead)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                attack = true;
                detect = true;
                if (timer > recoil)
                {
                    timer = 0f;
                    Instantiate(bullet, gunpoint.transform.position, Quaternion.identity);
                }
                if (zombie.transform.position.x - collider.gameObject.transform.position.x > 0)
                {
                    zombie.transform.localScale = zombie_script.Left;
                }
                else
                    zombie.transform.localScale = zombie_script.Right;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            attack = false;
            detect = false;
        }
    }
    void Update()
    {
        zombie_script.Attack = attack;
        zombie_script.Detect = detect;
        dead = zombie_script.Dead;
        timer += Time.deltaTime;
        transform.position = zombie.transform.position;
    }
}
