using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    //OptionMenu
    [Header("OptionsMenu")]
    [SerializeField]
    private GameObject optionMenu;
    [SerializeField]
    private Slider volumeSlider;
    [SerializeField]
    private Toggle fullScreenToggle;
    [SerializeField]
    private Button applyButton;

    [Space(10)]

    //MainMenu
    [Header("Main Menu")]
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button optionsButton;
    [SerializeField]
    private Button exitButton;

    private StateMachine stateMachine;
    private Dictionary<States, IState> states;

    /// <summary>
    /// Initializing all the states in a dictionary. 
    /// This way I don't have to initialize a new state over again. 
    /// </summary>
    private void Start()
    {
        states = new Dictionary<States, IState>();

        states.Add(States.MainMenu,new MainMenuState(playButton, optionsButton, exitButton,mainMenu));
        states.Add(States.PlayState,new PlayState());
        states.Add(States.OptionState,new OptionState(optionMenu, volumeSlider, fullScreenToggle, applyButton));
        states.Add(States.ExitState,new ExitState());

        stateMachine = new StateMachine(states);

        foreach (KeyValuePair<States,IState> item in states)
            item.Value.switchState += stateMachine.SwitchState;

        stateMachine.SwitchState(States.MainMenu);
    }
}
