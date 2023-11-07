using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kure : FallingObject
{
    public override void Collect() {
        var score = FindObjectOfType<Score>();
        score.ChangeScore(-10);
    }
}
