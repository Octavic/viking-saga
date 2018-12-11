namespace Assets.Scripts
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class Effect : MonoBehaviour
	{

		// Use this for initialization
		void Start()
		{
			StartCoroutine(this.RemoveAfter());
		}

		public IEnumerator RemoveAfter()
		{
			yield return new WaitForSeconds(0.3f);
			Destroy(this.gameObject);
		}
	}
}