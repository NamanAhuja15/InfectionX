using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shooting : MonoBehaviour
{
    private Animator animator;
    private float time,lastfired;
    private bool shoot,fire;
    private AudioManager manager;
    public ParticleSystem Muzzle;
    public GameObject Bullet, Gunpoint,Missile;
    public float Firerate, Missilerate, Bullets, Missiles;
    public bool Gun, Rocket;
    void Start()
    {
        animator = GetComponent<Animator>();
        manager = GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (SimpleInput.GetButton("Fire")) 
        {
            if(Time.time-lastfired>1/Firerate&&Bullets>0)
            {
                lastfired = Time.time;
                shoot = true;
                Instantiate(Bullet,new Vector3(Gunpoint.transform.position.x,Gunpoint.transform.position.y,0),Quaternion.identity);
                Muzzle.Play();
                Bullets--;
                manager.Shoot(2);
            }
        }
        if (SimpleInput.GetButton("Rocket"))
        {
            if (time > Missilerate && Missiles > 0)
            {
                shoot = true;
                Instantiate(Missile, Gunpoint.transform.position, Quaternion.identity);
                time = 0f;
                Missiles--;
                manager.Shoot(1);
            }
        }
        if (SimpleInput.GetButtonUp("Fire"))
        {
            shoot = false;
            Muzzle.Stop();
        }
        if(SimpleInput.GetButtonUp("Rocket"))
        {
            shoot = false;
        }
        animator.SetBool("Shoot", shoot);
    }

    public void Reset()
    {
        shoot = false;
        Muzzle.Stop();
    }
}
