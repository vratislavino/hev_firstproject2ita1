
using UnityEngine;
using UnityEngine.AI;

public abstract class State
{
    protected Symbol enemySymbol;
    protected Symbol playerSymbol;

    protected NavMeshAgent agent;

    public State(Symbol enemySymbol, Symbol playerSymbol) {
        this.enemySymbol = enemySymbol;
        this.playerSymbol = playerSymbol;
        this.agent = enemySymbol.GetComponent<NavMeshAgent>();
    }

    public abstract void Init();

    public abstract void Update();

    public abstract State GetNewState();
}
