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
        Exit();
    }

    public void Exit()
    {
        SceneManager.LoadScene(1);
    }
}
