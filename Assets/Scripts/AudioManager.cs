using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] footsteps;
    public AudioClip JumpSound;
    public AudioClip Shoot_;
    public AudioClip Laser_Shoot;
    private AudioSource audioSource;
    private float time = 0f,delay=0.1f;
    private int index = 0;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Shoot(int index)
    {
        if(index==1)
        {
            audioSource.PlayOneShot(Shoot_);
        }
        if(index==2)
        {
            audioSource.PlayOneShot(Laser_Shoot);

        }
    }
    public void Jump()
    {
        audioSource.PlayOneShot(JumpSound);
    }
    public void Walk()
    {
        if(time>delay)
        {
            time = 0f;
            audioSource.PlayOneShot(footsteps[index]);
            index++;
            if(index>=footsteps.Length)
            {
                index = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
}
