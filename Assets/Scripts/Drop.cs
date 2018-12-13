namespace Assets.Scripts
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using UnityEngine;

	public class Drop : MonoBehaviour
	{
		public int Money;
		public bool Potion;

		protected void Update()
		{
			if ((PlayerController.CurrentInstance.transform.position - this.transform.position).magnitude < 10)
			{
				PlayerController.CurrentInstance.AddDrop(this.Money, this.Potion);
				Destroy(this.gameObject);
			}
		}
	}
}
