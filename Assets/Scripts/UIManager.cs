using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public GameObject Player;
    public Text bullet_count;
    public Text rocket_count;
    public Text health;
    public Slider Healthbar;
    private Player_Health health_script;
    private Shooting ammo;
    void Start()
    {
        health_script = Player.GetComponent<Player_Health>();
        ammo = Player.GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        bullet_count.text = ammo.Bullets.ToString();
        rocket_count.text = ammo.Missiles.ToString();
        Healthbar.value = health_script.health/100f;
        health.text = health_script.health.ToString() + "/100";
    }
}
