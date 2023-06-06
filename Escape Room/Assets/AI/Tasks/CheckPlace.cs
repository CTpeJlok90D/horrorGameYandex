using AI.Tasks;
using AI.Memory;

public class CheckPlace : Task
{
	public override void OnBegin()
	{
		base.OnBegin();
	}

	public override void OnTakeNewInfo(FactorInfo info)
	{
		base.OnTakeNewInfo(info);
		Agent.destination = info.SourceTransform.position;
	}
}
