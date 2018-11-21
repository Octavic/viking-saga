namespace Assets.Scripts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    public class HpBar : MonoBehaviour
    {
        public GameObject obj;

        public void Set(float val)
        {
            obj.transform.localScale = new Vector3(val, 1);
            obj.transform.localPosition = new Vector3((val - 1) / 2, 0);
        }
    }
}
