
namespace Assets.Scripts
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using UnityEngine;

	public class Entity : MonoBehaviour
	{
		public Sprite Normal;
		public Sprite Attack;
		public Sprite Death;
		public bool IsInvincible;

		public bool IsAttacking { get; protected set; }

		public EntityFaction Faction;

		public float TotalHP;
		public float CurrentHP
		{
			get
			{
				return this._currentHP;
			}
			set
			{
				this._currentHP = value;
				if (this._currentHP < 0)
				{
					this.OnDeath();
				}
				this.HpBarObj.Set(this._currentHP / this.TotalHP);
			}
		}
		private float _currentHP;

		public bool IsFacingRight
		{
			get
			{
				return this._isFacingRight;
			}
			set
			{
				if (value != this._isFacingRight)
				{
					this.scaleGoal = new Vector3(value ? 1 : -1, 1);
					this._isFacingRight = value;
				}
			}
		}
		private bool _isFacingRight;

		private HpBar HpBarObj;

		private Vector3 scaleGoal = new Vector3(1, 1);
		protected SpriteRenderer spriteRenderer;

		public virtual void OnHit(bool fromRight, float damageTaken)
		{
			var newHitSpark = Instantiate(PlayerController.CurrentInstance.HitSpark);
			newHitSpark.transform.position = this.transform.position;
			this.CurrentHP -= damageTaken;
		}
		public void OnDeath()
		{
			var corpse = new GameObject();
			corpse.transform.position = this.transform.position;
			var corpseRenderer = corpse.AddComponent<SpriteRenderer>();
			corpseRenderer.sprite = this.Death;
			corpseRenderer.sortingOrder = -1;

			Destroy(this.gameObject);
		}

		protected virtual void Start()
		{
			this.IsFacingRight = true;
			this._currentHP = this.TotalHP;
			this.HpBarObj = this.GetComponentInChildren<HpBar>();
			this.spriteRenderer = this.GetComponent<SpriteRenderer>();
		}

		protected virtual void Update()
		{
			this.transform.localScale = Vector3.Lerp(this.transform.localScale, this.scaleGoal, 0.5f);
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

	}
}
