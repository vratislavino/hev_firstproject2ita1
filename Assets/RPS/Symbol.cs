using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol : MonoBehaviour
{
    SymbolEnum currentSymbol;

    [SerializeField]
    private bool isPlayer;

    [SerializeField]
    private MeshRenderer quad;

    [SerializeField]
    private Material[] materials;


    void Start()
    {
        ChangeSymbol(GetRandomSymbol());
        if(isPlayer) {
            StartCoroutine(ChangeSymbolRoutine());
        }
    }

    IEnumerator ChangeSymbolRoutine() {
        while(true) {
            yield return new WaitForSeconds(2);
            ChangeSymbol(GetRandomSymbol());
        }
    }

    private SymbolEnum GetRandomSymbol() {
        return (SymbolEnum)Random.Range(0, 3);
    }

    private void ChangeSymbol(SymbolEnum symbol) {
        currentSymbol = symbol;
        quad.material = materials[(int)symbol];
    }
}

public enum SymbolEnum
{
    Rock, Paper, Scissors
}