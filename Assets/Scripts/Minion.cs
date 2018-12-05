
namespace Assets.Scripts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    public class Minion : Entity
    {
        private Vector3 goal;

        public virtual void UnitAttack()
        {

        }

        public void MoveTo(Vector3 goal)
        {
            this.goal = goal;
        }

        protected override void Update()
        {
            base.Update();
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, this.goal, 0.3f);
        }
    }
}
