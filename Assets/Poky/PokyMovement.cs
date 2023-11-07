using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokyMovement : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float border;

    void Update()
    {
        // Time.deltaTime

        float xMove = 0;

        if(Input.GetKey(KeyCode.A)) {
            xMove = -1;
        }
        if (Input.GetKey(KeyCode.D)) {
            xMove = 1;
        }

        transform.Translate(xMove * Time.deltaTime * speed, 0, 0);
    
        if(transform.position.x < -border) {
            transform.position = new Vector3(-border, transform.position.y, transform.position.z); 
        }
        if (transform.position.x > border) {
            transform.position = new Vector3(border, transform.position.y, transform.position.z);
        }

    }
    
    private void OnCollisionEnter(Collision collision) {

        Debug.Log("collision!");
        var obj = collision.gameObject.GetComponent<FallingObject>();
        if (obj) {
            obj.Collect();
        }

        Destroy(collision.gameObject);
    }
}
