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

        // If the player is close to a game over or winning the game:
        if (nextStates.Length == 1)
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
            for (int i = 0; i < nextStates.Length; i++)
            {

                // If the player types "1" or "2" in their keyboard:
                if (Input.GetKeyDown(KeyCode.Alpha1 + i) || Input.GetKeyDown(KeyCode.Keypad1 + i))
                {
                    state = nextStates[i];
                }
            }
        }

        // Updates the next state:
        textComponent.text = state.GetStateStory();
    }
}
