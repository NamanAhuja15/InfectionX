using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    private float bullet_count, rocket_count,Player_health;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bullet_count = Shooting.instance.bullets;
        rocket_count = Shooting.instance.missiles;
        Player_health = Player_Health.instance.health;
    }
}
