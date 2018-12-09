namespace Assets.Scripts
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class EnemyRangedUnit : RangedMinion
	{
		public bool AttackFromRight;
		public float MovementSpeed;
		public float AttackRange;

		protected override void Start()
		{
			base.Start();
			this.IsFacingRight = !this.AttackFromRight;
			this.MovementGoal = this.transform.position;
		}

		protected override void Update()
		{
			base.Update();
			if (this.IsAttacking)
			{
				return;
			}

			var target = PlayerController.CurrentInstance.TargetFrom(this.AttackFromRight);
			var targetPosition = target.transform.position + new Vector3(AttackFromRight ? AttackRange : -AttackRange, 0);
			targetPosition.x = this.transform.position.x;
			var positionDiff = targetPosition - this.transform.position;
			if (positionDiff.magnitude < this.AttackRange)
			{
				this.UnitAttack();
			}
			else
			{
				this.MovementGoal = this.transform.position + positionDiff.normalized * this.MovementSpeed * Time.deltaTime;
			}
		}

		protected virtual void OnTriggerEnter2D(Collider2D collision)
		{
			var hitbox = collision.GetComponent<Hitbox>();
			if (hitbox != null && hitbox.Faction != this.Faction)
			{
				this.OnHit(true, hitbox.Damage);
			}

			var arrow = collision.GetComponent<Arrow>();
			if (arrow != null && arrow.FromFaction != this.Faction)
			{
				this.OnHit(true, arrow.Damage);
				Destroy(arrow.gameObject);
			}
		}

		protected override IEnumerator AttackRoutine()
		{
			yield return base.AttackRoutine();
			this.IsAttacking = true;
			yield return new WaitForSeconds(3);
			this.IsAttacking = false;
		}
	}
}