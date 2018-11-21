
namespace Assets.Scripts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    public class Entity : MonoBehaviour
    {
        public EntityFaction Faction;

        public float TotalHP;
        public float CurrentHP
        {
            get
            {
                return this._currentHP;
            }
            protected set
            {
                this._currentHP = value;
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

        public void OnHit(float damageTaken)
        {
            this.CurrentHP -= damageTaken;
        }

        protected virtual void Start()
        {
            this.IsFacingRight = true;
            this._currentHP = this.TotalHP;
            this.HpBarObj = this.GetComponentInChildren<HpBar>();
        }

        protected virtual void Update()
        {
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, this.scaleGoal, 0.5f);
        }
    }
}
