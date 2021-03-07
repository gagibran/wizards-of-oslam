using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{

    // Serializing a field (or variable), making it available to edit into Unity. Using the data type UnityEngine.UI.Text:
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    // Declaring the current state variable:
    State state;

    // Start is called before the first frame update
    void Start()
    {
        // Initializing the current state with the starting one.
        // This has to be done in order to "state" to have a value. In this case, the value comes from the serialized field:
        state = startingState;

        // In the beginning, state will be the starting state:
        // Updating the game with this text when we click on the play button:
        textComponent.text = startingState.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    // Storying the next states of a state within an array:
    private void ManageState()
    {
        State[] nextStates = state.GetNextStates();

        // If the player types "1", "2", or "3" in their keyboard:
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            state = nextStates[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            state = nextStates[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            state = nextStates[2];
        }

        // Updates the next state:
        textComponent.text = state.GetStateStory();
    }
}
