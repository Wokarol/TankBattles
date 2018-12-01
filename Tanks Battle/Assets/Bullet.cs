using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wokarol.HealthSystem;
using Wokarol.PoolSystem;

namespace Wokarol.WeaponSystem
{
    public class Bullet : PoolObject
    {
        [SerializeField] new Rigidbody2D rigidbody = null;
        [SerializeField] GameObject gfx = null;
        [Space]
        [SerializeField] float startVelocity = 3;
        [SerializeField] Vector3 velocityVector = Vector3.up;
        [Space]
        [SerializeField] bool penetration = false;
        [SerializeField] int damage = 5;
        [SerializeField] float radius = 2;

        bool active;

        public override void Destroy()
        {
            Deactivate();
            base.Destroy();
        }

        public override void Activate()
        {
            gfx.SetActive(true);
            rigidbody.simulated = true;
            active = true;
        }

        public override void Deactivate()
        {
            gfx.SetActive(false);
            rigidbody.simulated = false;
            active = false;
        }

        public override void Recreate()
        {
            Activate();
            rigidbody.velocity = transform.TransformDirection(velocityVector) * startVelocity;
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            var targets = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach (var target in targets) {
                target.GetComponentInParent<IExplodeable>()?.RegisterExplosion(transform.position, radius);
                target.GetComponentInParent<IDamagable>()?.Hit(damage);
            }
            Destroy();
        }

        private void OnDrawGizmos() {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
