namespace Assets.Scripts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    public class Hitbox : MonoBehaviour
    {
        public EntityFaction Faction;
        public float Damage;
        public bool CanHitMultiple;
        public bool IsFacingRight { get; set; }
    }
}
