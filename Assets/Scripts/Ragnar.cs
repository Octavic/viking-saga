
namespace Assets.Scripts
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using UnityEngine.SceneManagement;

	public class Ragnar : Entity
	{
		protected override void Start()
		{
			base.Start();
		}

		public override void OnDeath()
		{
			SceneManager.LoadScene(2);
			base.OnDeath();
		}
	}
}
