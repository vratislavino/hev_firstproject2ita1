using UnityEngine;

public class IdleState : State
{
    Vector3 target;

    public IdleState(Symbol enemySymbol, Symbol playerSymbol) : base(enemySymbol, playerSymbol) {
    }

    private void GenerateNewTarget() {
        Vector3 point = new Vector3(Random.Range(0f,100f), 60f, Random.Range(0f, 100f));
        // vytvoøení bodu na terénu
        if(Physics.Raycast(point, Vector3.down, out RaycastHit hit, 61f)) {
            target = hit.point;
            GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = target;
        }
    }


    public override void Init() {
        GenerateNewTarget();
    }

    public override void Update() {
        agent.SetDestination(target);
        if (Vector3.Distance(target, agent.transform.position) < 2) {
            GenerateNewTarget();
        }
    }

    public override State GetNewState() {
        return null;
    }
}
