using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour
{

    // Serializing a field (or variable), making it available to edit into Unity, in "Game Logic". Using the data type TMPro.TextMeshProUGUI:
    [SerializeField] TextMeshProUGUI textComponent;
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
        string stateName = state.GetStateName();

        // If the player is close to a game over or winning the game:
        if (stateName.Equals("S7_Sleep") || stateName.Equals("S9_HitemWithHead") || stateName.Equals("S11_RushToTheExit") ||
            stateName.Equals("S12_ConnectIntoTheMatrix") || stateName.Equals("S13_ContinueExploring"))
        {

            // If the player hits the "enter" key:
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                state = nextStates[0];
            }
        }

        // If the player is in a normal state:
        else
        {

            // If the player types "1" or "2" in their keyboard:
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                state = nextStates[0];
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                state = nextStates[1];
            }
        }

        // Updates the next state:
        textComponent.text = state.GetStateStory();
    }
}
