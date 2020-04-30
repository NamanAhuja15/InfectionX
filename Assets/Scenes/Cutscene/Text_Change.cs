using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Text_Change : MonoBehaviour
{
    public Text text;
    private float time = 0f;
    public float change;
    public AudioSource audiosource,ship;
    public AudioClip mayday, report, crashing,flying;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time==0.1f)
        {
            ship.PlayOneShot(flying);
            audiosource.PlayOneShot(report);
        }
        if (time>=change)
        {
            text.text = "MAYDAY!MAYDAY!MAYDAY!Requesting backup";
            audiosource.clip = null;
            ship.clip = null;
            audiosource.PlayOneShot(mayday);
            ship.PlayOneShot(crashing);
        }
    }
}
