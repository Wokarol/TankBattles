using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdhesionForce : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    [SerializeField] float force;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionStay2D(Collision2D collision) {
        Debug.Log(":D");
        rigidbody.AddForce(-collision.contacts[0].normal * force);
        Debug.DrawRay(transform.position, -collision.contacts[0].normal);
    }
}
