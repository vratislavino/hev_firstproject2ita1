using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        var player = other.GetComponentInParent<PlayerController>();
        if (player != null)
        {
            player.Rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }
    }
}
