
namespace Assets.Scripts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    public class Minion : Entity
    {
        protected Vector3 MovementGoal;

        public virtual void UnitAttack()
        {

        }

        public void MoveTo(Vector3 goal)
        {
            this.MovementGoal = goal;
        }

        protected override void Update()
        {
            base.Update();
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, this.MovementGoal, 0.3f);
        }
    }
}
