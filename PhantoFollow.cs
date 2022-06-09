using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantoFollow : MonoBehaviour
{
    [HideInInspector] public Prototype_player_movement prototype_player_movement;

    float movementX;
    float movementY;

    public float accelerationX;
    public float accelerationY;

    public float maxSpeedX;
    public float maxSpeedY;

    // Start is called before the first frame update
    void Start()
    {
        prototype_player_movement = FindObjectOfType<Prototype_player_movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(prototype_player_movement.transform.position.x < transform.position.x && movementX > -maxSpeedX) {
            movementX -= accelerationX;
        } else if (prototype_player_movement.transform.position.x > transform.position.x && movementX < maxSpeedX) {
            movementX += accelerationX;
        }
        if(prototype_player_movement.transform.position.y < transform.position.y && movementX > -maxSpeedY) {
            movementY -= accelerationY;
        } else if (prototype_player_movement.transform.position.y > transform.position.y && movementY < maxSpeedY) {
            movementY += accelerationY;
        }
        transform.Translate(movementX*Time.deltaTime, movementY*Time.deltaTime, 0);
        Debug.Log("X:" + movementX + ",Y:" + movementY);
    }
}
