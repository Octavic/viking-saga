namespace Assets.Scripts
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class ShieldMinion : MeleeMinion
	{
		public bool IsShielding;
		public bool IsPerfectShield;
		public Effect PerfectShieldEffect;

		public override void UnitAttack()
		{
			this.IsShielding = true;
			this.IsPerfectShield = true;
			this.spriteRenderer.sprite = this.Attack;
			StartCoroutine(ExpirePerfectShield());
		}
		public IEnumerator ExpirePerfectShield()
		{
			yield return new WaitForSeconds(0.5f);
			this.IsPerfectShield = false;
		}
		public override void UnitAttackRelease()
		{
			this.IsShielding = false;
			this.spriteRenderer.sprite = this.Normal;
		}
		public override void OnHit(bool fromRight, float damageTaken)
		{
			if(IsPerfectShield)
			{
				var newShield = Instantiate(this.PerfectShieldEffect);
				newShield.transform.position = this.transform.position;
				return;
			}
			if(IsShielding)
			{
				var newShield = Instantiate(this.PerfectShieldEffect);
				newShield.GetComponent<SpriteRenderer>().color = Color.red;
				newShield.transform.position = this.transform.position;
				damageTaken /= 2;
			}

			base.OnHit(fromRight, damageTaken);
		}
	}
}
