
namespace Assets.Scripts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    public class Entity : MonoBehaviour
    {
        public bool IsFacingRight { get; private set; }

        private Vector3 scaleGoal = new Vector3(1, 1);

        public void Flip()
        {
            this.scaleGoal = new Vector3(this.IsFacingRight ? -1 : 1, 1);
            this.IsFacingRight = !this.IsFacingRight;
        }

        protected virtual void Update()
        {
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, this.scaleGoal, 0.5f);
        }
    }
}
