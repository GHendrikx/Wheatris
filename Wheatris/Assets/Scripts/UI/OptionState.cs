﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionState : IState
{
    public event SwitchState switchState;

    private GameObject optionsMenu;
    private Slider volumeSlider;
    private Toggle fullScreenToggle;
    private Button applyButton;

    /// <summary>
    /// Setting the option state variables.
    /// </summary>
    public OptionState(GameObject _optionMenu, Slider _volumeSlider, Toggle _fullScreenToggle,Button _applyButton)
    {
        optionsMenu = _optionMenu;
        volumeSlider = _volumeSlider;
        fullScreenToggle = _fullScreenToggle;
        applyButton = _applyButton;
    }

    
    public void Enter()
    {
        Debug.Log("Enter");
        optionsMenu.SetActive(true);
        applyButton.onClick.AddListener(() => ApplySettings());
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }

    public void ApplySettings()
    {
        //Fullscreen toggle
        if (fullScreenToggle.isOn)
            Screen.fullScreen = true;
        else
            Screen.fullScreen = false;

        //Setting the playerpref float
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        optionsMenu.SetActive(false);
        switchState.Invoke(States.MainMenu);
    }

    public void Exit()
    {

    }

}
