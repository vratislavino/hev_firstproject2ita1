using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    State currentState;

    void Start()
    {
        var pl = FindObjectsOfType<Symbol>().ToList().First(s => s.IsPlayer);
        currentState = new IdleState(GetComponent<Symbol>(), pl);
        currentState.Init();
    }

    void Update()
    {
        currentState.Update();
        var newState = currentState.GetNewState();
        if(newState != null) {
            currentState = newState;
            currentState.Init();
        }
    }
}
