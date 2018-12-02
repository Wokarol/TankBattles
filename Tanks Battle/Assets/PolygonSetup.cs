using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonSetup : MonoBehaviour
{
    [SerializeField] SpriteRenderer renderer = null;
    [SerializeField] PolygonCollider2D collider = null;
 
    [ContextMenu("Set")]
    public void Set() {
        int count = renderer.sprite.GetPhysicsShapeCount();
        collider.pathCount = count;

        for (int i = 0; i < count; i++) {
            var points = new List<Vector2>();
            renderer.sprite.GetPhysicsShape(i, points);
            collider.SetPath(i, points.ToArray());
        }
    }
}
