using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")] // Creates a "State" option in "Create", in Assets.
public class State : ScriptableObject
{
    [TextArea(20, 30)] [SerializeField] string storyText;
    [SerializeField] State[] nextStates; // Storying the next states. The contents of this array will have access to storyText.

    // Getters:
    public string GetStateStory()
    {
        return storyText;
    }
    public State[] GetNextStates()
    {
        return nextStates;
    }
    public string GetStateName()
    {
        return name;
    }
}
