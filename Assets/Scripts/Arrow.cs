namespace Assets.Scripts
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    public class Arrow : MonoBehaviour
    {
        public EntityFaction FromFaction;

        public float Velocity;
        public float Damage;
        public bool IsFacingRight { get; set; }

        protected void Update()
        {
            var movement = this.Velocity * Time.deltaTime;
            if (!this.IsFacingRight)
            {
                movement *= -1;
            }
            this.transform.localPosition += new Vector3(movement, 0);
        }
    }
}
