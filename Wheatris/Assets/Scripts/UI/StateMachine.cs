using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private Dictionary<States, IState> states = new Dictionary<States, IState>();
    private IState currentState;

    public StateMachine(Dictionary<States,IState> _states)
    {
        this.states = _states;
    }

    /// <summary>
    /// Setting new state
    /// </summary>
    public void SwitchState(States _nextState)
    {
        //exiting state
        if(currentState != null)
            currentState.Exit();

        //Setting next state
        currentState = states[_nextState];

        //entering next state
        currentState.Enter();
    }
}

public enum States
{
    MainMenu,
    PlayState,
    OptionState,
    ExitState
}