using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // transform.position = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
