using AI.Memory;
using UnityEngine;

public class Harassment : CheckPlace
{
	public override void OnUpdate()
	{
		Agent.destination = Info.SourceTransform.position;
	}
}
