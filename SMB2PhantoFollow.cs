using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMB2PhantoFollow : MonoBehaviour
{
    [HideInInspector] public Prototype_player_movement prototype_player_movement;
    [HideInInspector] public CameraFollow cameraFollow;

    float movementX;
    float movementY;

    public float accelerationX;
    public float accelerationY;

    public float maxSpeedX;
    public float maxSpeedY;

    [HideInInspector] public float relativeXLocation;
    [HideInInspector] public float desiredXLocation;
    [HideInInspector] public float desiredYLocation;
    public bool moveLeft;

    // Start is called before the first frame update
    void Start()
    {
        prototype_player_movement = FindObjectOfType<Prototype_player_movement>();
        cameraFollow = FindObjectOfType<CameraFollow>();
        moveLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveLeft && cameraFollow.transform.position.x-5 > transform.position.x) {
            moveLeft = false;
        } else if (!moveLeft && cameraFollow.transform.position.x+5 < transform.position.x) {
            moveLeft = true;
        }
        if (moveLeft && movementX > -maxSpeedX) {
            movementX -= accelerationX;
        } else if (!moveLeft && movementX < maxSpeedX) {
            movementX += accelerationX;
        }
        relativeXLocation += movementX*Time.deltaTime;
        desiredXLocation = cameraFollow.transform.position.x + relativeXLocation;
        if(prototype_player_movement.transform.position.y < transform.position.y && movementY > -maxSpeedY) {
            movementY -= accelerationY;
        } else if (prototype_player_movement.transform.position.y > transform.position.y && movementY < maxSpeedY) {
            movementY += accelerationY;
        }
        desiredYLocation += movementY*Time.deltaTime;
        transform.position = new Vector2(desiredXLocation, desiredYLocation);
    }
}
