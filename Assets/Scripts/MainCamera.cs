namespace Assets.Scripts
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class MainCamera : MonoBehaviour
	{

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			var targetPos = PlayerController.CurrentInstance.transform.position;
			targetPos.x = Mathf.Max(targetPos.x, 0);
			targetPos.y = 0;
			targetPos.z = -10;
			this.transform.position = targetPos;
		}
	}
}