namespace Assets.Scripts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class EnemyMeleeUnit : MeleeMinion
    {
        protected override void Start()
        {
            base.Start();
            this.MovementGoal = this.transform.position;
        }

        protected override void Update()
        {
            base.Update();

        }

        protected void OnTriggerEnter2D(UnityEngine.Collider2D collision)
        {
            var hitbox = collision.GetComponent<Hitbox>();
            if (hitbox != null && hitbox.Faction != this.Faction)
            {
                this.OnHit(hitbox.Damage);
            }

            var arrow = collision.GetComponent<Arrow>();
            if (arrow != null && arrow.FromFaction != this.Faction)
            {
                this.OnHit(arrow.Damage);
                Destroy(arrow.gameObject);
            }
        }
    }
}
