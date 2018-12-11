namespace Assets.Scripts
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	[System.Serializable]
	public struct SpawnLocation
	{
		public float Position;
		public List<EnemyMeleeUnit> Melees;
		public List<EnemyRangedUnit> Ranges;
	}
	public class SpawnManager : MonoBehaviour
	{
		public List<SpawnLocation> Spawns;
		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			if (this.Spawns.Count == 0)
			{
				return;
			}

			var first = this.Spawns[0];
			if (PlayerController.CurrentInstance.transform.position.x < first.Position)
			{
				return;
			}

			foreach (var m in first.Melees)
			{
				m.gameObject.SetActive(true);
			}
			foreach (var r in first.Ranges)
			{
				r.gameObject.SetActive(true);
			}
			this.Spawns.RemoveAt(0);
		}
	}

}
