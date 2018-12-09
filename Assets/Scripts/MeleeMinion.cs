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
            this.MeleehHitbox.IsFacingRight = this.IsFacingRight;
            this.IsAttacking = true;
            this.MeleehHitbox.gameObject.SetActive(true);
            this.spriteRenderer.sprite = this.Attack;
            yield return new WaitForSeconds(0.3f);
            this.IsAttacking = false;
            this.MeleehHitbox.gameObject.SetActive(false);
            this.spriteRenderer.sprite = this.Normal;
        }
    }
}
