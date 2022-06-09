using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : MonoBehaviour
{
    [HideInInspector] public Prototype_player_movement prototype_player_movement;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        prototype_player_movement = FindObjectOfType<Prototype_player_movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < prototype_player_movement.transform.position.x)
        {
            transform.Translate (speed * Time.deltaTime,0,0);
        }
        if (transform.position.x > prototype_player_movement.transform.position.x)
        {
            transform.Translate (-speed * Time.deltaTime,0,0);
        }
        if  (transform.position.y > prototype_player_movement.transform.position.y)
        {
            transform.Translate (0,-speed * Time.deltaTime,0);
        } 
        if (transform.position.y < prototype_player_movement.transform.position.y)
        {
            transform.Translate (0,speed * Time.deltaTime,0);
        }
    }
}
