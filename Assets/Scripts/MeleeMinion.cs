namespace Assets.Scripts
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    public class MeleeMinion : Minion
    {
        public Hitbox MeleehHitbox;

        public override void UnitAttack()
        {
            if (this.IsAttacking)
            {
                return;
            }

            StartCoroutine(this.AttackRoutine());
        }

        private IEnumerator AttackRoutine()
        {
            this.IsAttacking = true;
            this.MeleehHitbox.gameObject.SetActive(true);
            this.renderer.sprite = this.Attack;
            yield return new WaitForSeconds(0.3f);
            this.IsAttacking = false;
            this.MeleehHitbox.gameObject.SetActive(false);
            this.renderer.sprite = this.Normal;
        }
    }
}
