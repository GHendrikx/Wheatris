using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayState : IState
{
    public event SwitchState switchState;

    /// <summary>
    /// Enter the state
    /// </summary>
    public void Enter()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Exit the state
    /// </summary>
    public void Exit()
    {
        
    }
}
