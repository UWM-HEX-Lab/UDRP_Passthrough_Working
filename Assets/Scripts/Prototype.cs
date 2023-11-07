using System;
using System.Collections.Generic;
using UnityEngine;

enum PlayerState
{
    State0,
    State1,
    State2
}





class SoccerPlayerStateMachine : MonoBehaviour
{
    private PlayerState currentState;

    public GameObject teammate1;
    public GameObject teammate2; 
    public GameObject teammate3;
    public GameObject goalie;
    public GameObject opponent1;
    public GameObject opponent2;
    public SoccerPlayerStateMachine()
    {
        currentState = PlayerState.State0;
    }

    public void TransitionState()
    {
        switch (currentState)
        {
            case PlayerState.State0:
                currentState = PlayerState.State1;
                teammate1.transform.position = new Vector3(-103, 2, 37);
                teammate2.transform.position = new Vector3(-120, 2, 10);
                teammate3.transform.position = new Vector3(0, -2, 0);
                goalie.transform.position = new Vector3(-146, 2, 0);
                opponent1.transform.position = new Vector3(-95, 2, 40);
                opponent2.transform.position = new Vector3(0, -2, 0);
                // add logic to add goalie, one teammate, and an opponent
                break;
            case PlayerState.State1:
                currentState = PlayerState.State2;
                // add logic to add goalie, 2 teammates, and anopponent defending a teammate
                break;
            case PlayerState.State2:
                currentState = PlayerState.State0;
                
                break;
        }
    }
}

class Program
{
    static void Main()
    {
        SoccerPlayerStateMachine soccerStateMachine = new SoccerPlayerStateMachine();

        Console.WriteLine("Starting Soccer Player State Machine Prototype.");

        bool exit = false;
        while (!exit)
        {
            Debug.Log("\nPress 't' to transition to the next state or 'q' to quit:");
            var input = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (input)
            {
                case 't':
                    soccerStateMachine.TransitionState();
                    break;
                case 'q':
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please press 't' to transition or 'q' to quit.");
                    break;
            }
        }
    }
}
