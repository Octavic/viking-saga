using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController CurrentInstance { get; private set; }

        /// <summary>
        /// How far away the minions are from each other
        /// </summary>
        public float MinionDistance;
        public float MinionHeight;

        public Ragnar RagnarObj;
        public Vector2 Speed;

        public bool IsFacingRight { get { return this.RagnarObj.IsFacingRight; } }
        public int FrontUnitIndex
        {
            get
            {
                return this.IsFacingRight ? 3 : 0;
            }
        }
        public Minion FrontMinion
        {
            get
            {
                return this.minions[this.FrontUnitIndex];
            }
        }

        private List<Minion> minions;
        private List<int> minionIndexes = new List<int>() { -2, -1, 1, 2 };

        private Dictionary<KeyCode, int> SwapIndex = new Dictionary<KeyCode, int>()
        {
            {KeyCode.Alpha1, 0 },
            {KeyCode.Alpha2, 1 },
            {KeyCode.Alpha3, 2 },
            {KeyCode.Alpha4, 3 },
        };

        // Use this for initialization
        void Start()
        {
            this.minions = new List<Minion>(this.transform.GetComponentsInChildren<Minion>());
            this.RenderMinions();

            PlayerController.CurrentInstance = this;   
        }

        // Update is called once per frame
        void Update()
        {
            float x = 0;
            float y = 0;
            if (Input.GetKey(KeyCode.D))
            {
                this.RenderMinions();
                x = 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                this.RenderMinions();
                x = -1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                y = 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                y = -1;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                this.FlipAll();
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                if (this.minions[3] != null)
                {
                    this.minions[3].OnHit(5);
                }
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (this.minions[0] != null)
                {
                    this.minions[0].OnHit(5);
                }
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                this.FrontMinion.UnitAttack();
            }

            foreach (var input in this.SwapIndex)
            {
                if (Input.GetKeyDown(input.Key))
                {
                    this.SwapMinion(input.Value, this.IsFacingRight ? 3 : 0);
                }
            }

            this.transform.position += new Vector3(this.Speed.x * x, this.Speed.y * y) * Time.deltaTime;

            for (int i = 0; i < this.minions.Count; i++)
            {
                if (this.minions[i] != null && this.minions[i].CurrentHP <= 0)
                {
                    Destroy(this.minions[i].gameObject);
                }
            }
        }

        private void FlipAll()
        {
            var wasFacingRight = this.RagnarObj.IsFacingRight;
            foreach (var m in this.minions)
            {
                m.IsFacingRight = !wasFacingRight;
            }
            this.RagnarObj.IsFacingRight = !wasFacingRight;
        }

        private void SwapMinion(int index, int withIndex)
        {
            var moved = this.minions[index];
            var swap = this.minions[withIndex];
            this.minions[withIndex] = moved;
            this.minions[index] = swap;
            this.RenderMinions();
        }

        private void RenderMinions()
        {
            for (int i = 0; i < 4; i++)
            {
                this.minions[i].MoveTo(new Vector3(this.minionIndexes[i] * this.MinionDistance, MinionHeight));
            }
        }
    }
}
