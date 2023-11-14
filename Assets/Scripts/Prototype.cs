using System;
using System.Collections.Generic;
using UnityEngine;



public class Prototype : MonoBehaviour
{
    enum PlayerState 
    {
        State0,
        State1,
        State2
    }
    private PlayerState currentState = PlayerState.State0;

    public GameObject teammate1;
    public GameObject teammate2; 
    public GameObject teammate3;
    public GameObject goalie;
    public GameObject opponent1;
    public GameObject opponent2;

    void Start()
    {
       State0();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for button press
        if (Input.GetKeyDown(KeyCode.Space)) // Example: Spawn player on pressing Space
        {
            TransitionState();
        }
    }

    void State1(){
        teammate1.transform.position = new Vector3(-103, -3, 37);
        teammate2.transform.position = new Vector3(-120, -3, 10);
        teammate3.transform.position = new Vector3(0, -10, 0);
        goalie.transform.position = new Vector3(-146, -3, 0);
        opponent1.transform.position = new Vector3(-95, -3, 40);
        opponent2.transform.position = new Vector3(0, -10, 0);
    }
    void State2(){//change numbers
        teammate1.transform.position = new Vector3(-103, 0, 37);
        teammate2.transform.position = new Vector3(-120, 0, 10);
        teammate3.transform.position = new Vector3(0, -10, 0);
        goalie.transform.position = new Vector3(-146, 0, 0);
        opponent1.transform.position = new Vector3(-95, 0, 40);
        opponent2.transform.position = new Vector3(0, -10, 0);
    }
    void State0(){
        teammate1.transform.position = new Vector3(0, -10, 0);
        teammate2.transform.position = new Vector3(0, -10, 0);
        teammate3.transform.position = new Vector3(0, -10, 0);
        goalie.transform.position = new Vector3(0, -10, 0);
        opponent1.transform.position = new Vector3(0, -10, 0);
        opponent2.transform.position = new Vector3(0, -10, 0);
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
}
