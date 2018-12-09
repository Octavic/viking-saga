
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

		protected override void Update()
		{
			if(this.CurrentHP <= 0)
			{
				SceneManager.LoadScene(2);
			}

			base.Update();
		}
	}
}
