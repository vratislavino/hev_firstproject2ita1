using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        var player = other.GetComponentInParent<PlayerController>();
        if (player != null)
        {
            player.ChangeEnvironmentSpeedMultiplier(0.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other);
        var player = other.GetComponentInParent<PlayerController>();
        if (player != null)
        {
            player.ChangeEnvironmentSpeedMultiplier(1f);
        }
    }
}
