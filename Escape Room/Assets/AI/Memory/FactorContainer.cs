using UnityEngine;

namespace AI.Memory
{
	public class FactorContainer : MonoBehaviour
	{
		[SerializeField] private FactorInfo _info;

		public FactorInfo Info => _info;
	}
}
