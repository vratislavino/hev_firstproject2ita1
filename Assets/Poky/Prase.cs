using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prase : FallingObject
{
    public override void Collect() {
        var score = FindObjectOfType<Score>();
        score.ChangeScore(3);
    }
}
