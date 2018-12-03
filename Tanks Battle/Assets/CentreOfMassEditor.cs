using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CentreOfMassEditor : MonoBehaviour
{
    new Rigidbody2D rigidbody;


    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start() {
        rigidbody.centerOfMass = new Vector2(0, -1);
    }

    private void OnDrawGizmos() {
        if(!rigidbody) rigidbody = GetComponent<Rigidbody2D>();

        Gizmos.DrawWireSphere(rigidbody.worldCenterOfMass, 0.3f);
    }
}
