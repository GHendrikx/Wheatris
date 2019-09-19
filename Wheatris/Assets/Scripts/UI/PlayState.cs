using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayState : IState
{
    public event SwitchState switchState;

    public void Enter()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        
    }
}
