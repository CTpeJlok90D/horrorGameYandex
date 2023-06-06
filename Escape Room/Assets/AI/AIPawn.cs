using AI.Memory;
using UnityEngine;

public class AIPawn : MonoBehaviour
{
	[SerializeField] private AIDifficultLoader _loader;

	public Brain Brain => _loader.CurrentBrain;
}
