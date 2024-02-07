using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Prototype : MonoBehaviour
{
    enum PlayerState 
    {
        State0,
        State1,
        State2
    }
    private PlayerState currentState = PlayerState.State0;

    Random rand = new Random();

    public GameObject teammateCapsule1;
    public GameObject teammateCapsule2;
    public GameObject goalieCapsule;
    public GameObject opponentCapsule1;

    public float playerMoveSpeed = 1.0f;
    public float cameraRotationSpeed = 50.0f;

    void Start()
    {
        State0();
    }
    void Update()
    {
        //MovePlayers();
        RotateCamera();
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            TransitionState();
        }
    }
    void State0(){
        teammateCapsule1.transform.position = new Vector3(0, -10, 0);
        teammateCapsule2.transform.position = new Vector3(0, -10, 0);
                goalieCapsule.transform.position = new Vector3(0, -10, 0);
        opponentCapsule1.transform.position = new Vector3(0, -10, 0);
            }
    void State1(){
        teammateCapsule1.transform.position = new Vector3(3, (float) -.3, -17);
        teammateCapsule2.transform.position = new Vector3(-9, (float) -.3, -18);
        goalieCapsule.transform.position = new Vector3(2, (float)-.3, -12);
        opponentCapsule1.transform.position = new Vector3((float)2.5, (float)-.3, 14);
    }
    void State2(){
        teammateCapsule1.transform.position = new Vector3(-20, (float)1.7, -23);
        teammateCapsule2.transform.position = new Vector3(-39, (float)1.7, -15);
        goalieCapsule.transform.position = new Vector3(-52, (float)1.7, 0);
        opponentCapsule1.transform.position = new Vector3(-17, (float)1.7, -27);
    }
    public void TransitionState() {
        switch (currentState)
        {
        case PlayerState.State0:
            currentState = PlayerState.State1;
            State1();
            break;
        case PlayerState.State1:
            currentState = PlayerState.State2;
            State2();
            break;
        case PlayerState.State2:
            currentState = PlayerState.State0;
            State0();
            break;
        }
    }
    /*void MovePlayers()
    {
        int random = (int) rand.Next(0, 4);
        Vector3 movement;
        if (random == 0)
        {
            movement = new Vector3(Mathf.Sin(Time.time) * Time.deltaTime * playerMoveSpeed, 0, 0);
        }
        else
        {
            movement = new Vector3(0, 0, Mathf.Sin(Time.time) * Time.deltaTime * playerMoveSpeed);
        }
        teammate1.transform.position += movement;
        teammate2.transform.position += 3 * movement;
        teammate3.transform.position += 2 * movement;
        goalie.transform.position += -1 * movement;
        opponent1.transform.position += 3 * movement;
        opponent2.transform.position += -2 * movement;
    }*/
    void RotateCamera()
    {
        float horizontalRotation = Input.GetAxis("Horizontal") * cameraRotationSpeed * Time.deltaTime;
        float verticalRotation = -Input.GetAxis("Vertical") * cameraRotationSpeed * Time.deltaTime;

        transform.Rotate(0, horizontalRotation, 0);
        Camera camera = GetComponent<Camera>();
        if (camera != null)
        {
            camera.transform.Rotate(verticalRotation, 0, 0);
        }
    }
}
