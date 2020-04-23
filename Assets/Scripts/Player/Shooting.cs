using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shooting : MonoBehaviour
{
    private Animator animator;
    public float firerate,missilerate,bullets,missiles;
    private float time,lastfired;
    private bool shoot,fire;
    public ParticleSystem muzzle;
    public GameObject bullet, gunpoint,missile;
    private ParticleSystem muzzle_;
    public bool gun, rocket;
    public static Shooting instance;
    void Start()
    {
        animator = GetComponent<Animator>();
        muzzle_ = Instantiate(muzzle, gunpoint.transform);
        instance = this;
        gun = true;
        bullets = 10;
        missiles = 10;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (SimpleInput.GetButton("Fire")) 
        {
            if(Time.time-lastfired>1/firerate&&bullets>0)
            {
                lastfired = Time.time;
                shoot = true;
                Instantiate(bullet,new Vector3(gunpoint.transform.position.x,gunpoint.transform.position.y,0),Quaternion.identity);
                muzzle_.Play();
                bullets--;
                //muzzle_ = Instantiate(muzzle, gunpoint.transform);
              
            }
        }
        if (SimpleInput.GetButton("Rocket"))
        {
            if (time > missilerate && missiles > 0)
            {
                shoot = true;
                Instantiate(missile, gunpoint.transform.position, Quaternion.identity);
                time = 0f;
                missiles--;
            }
        }
        if (SimpleInput.GetButtonUp("Fire"))
        {
            shoot = false;
            muzzle_.Stop();
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
        muzzle_.Stop();
    }
}
