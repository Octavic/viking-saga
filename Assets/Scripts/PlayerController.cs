using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        /// <summary>
        /// How far away the minions are from each other
        /// </summary>
        public float MinionDistance;
        public float MinionHeight;

        public Ragnar RagnarObj;

        public Vector2 Speed;

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
        }

        // Update is called once per frame
        void Update()
        {
            int x = 0;
            int y = 0;
            if (Input.GetKey(KeyCode.D))
            {
                if (!RagnarObj.IsFacingRight)
                {
                    this.FlipAllMinions();
                }
                this.RenderMinions();
                x = 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                if (RagnarObj.IsFacingRight)
                {
                    this.FlipAllMinions();
                }
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

            foreach (var input in this.SwapIndex)
            {
                if (Input.GetKeyDown(input.Key))
                {
                    this.SwapMinion(input.Value, this.RagnarObj.IsFacingRight ? 3 : 0);
                }
            }

            this.transform.position += new Vector3(this.Speed.x * x, this.Speed.y * y) * Time.deltaTime;
        }

        private void FlipAllMinions()
        {
            foreach(var minion in this.minions)
            {
                minion.Flip();
            }
            this.RagnarObj.Flip();
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
