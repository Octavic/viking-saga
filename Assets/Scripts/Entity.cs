
namespace Assets.Scripts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    public class Entity : MonoBehaviour
    {
        public bool IsFacingRight
        {
            get
            {
                return this._isFacingRight;
            }
            set
            {
                if(value != this._isFacingRight)
                {
                    this.scaleGoal = new Vector3(value ? 1 : -1, 1);
                    this._isFacingRight = value;
                }
            }
        }
        private bool _isFacingRight;

        private Vector3 scaleGoal = new Vector3(1, 1);

        protected virtual void Start()
        {
            this.IsFacingRight = true;
        }

        protected virtual void Update()
        {
            this.transform.localScale = Vector3.Lerp(this.transform.localScale, this.scaleGoal, 0.5f);
        }
    }
}
