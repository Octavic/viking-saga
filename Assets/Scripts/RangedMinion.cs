namespace Assets.Scripts
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    public class RangedMinion : Minion
    {
        public Arrow ArrowPrefab;

        public override void UnitAttack()
        {
            if (this.IsAttacking)
            {
                return;
            }

            var newArrow = Instantiate(this.ArrowPrefab);
            if (!this.IsFacingRight)
            {
                newArrow.transform.localScale = new Vector3(-1, 1, 1);
            }

            newArrow.transform.position = this.transform.position;
            this.StartCoroutine(this.AttackRoutine());
        }
        private IEnumerator AttackRoutine()
        {
            this.IsAttacking = true;
            this.renderer.sprite = this.Attack;
            yield return new WaitForSeconds(0.3f);
            this.IsAttacking = false;
            this.renderer.sprite = this.Normal;
        }
    }
}
