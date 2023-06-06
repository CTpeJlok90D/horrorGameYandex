using AI.Memory;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace AI.Tasks
{
    public abstract class Task : MonoBehaviour
    {
        [Header("Task")]
        [SerializeField] private AIDoorOpener _opener;
		[SerializeField] private NavMeshAgent _agent;
		[SerializeField] private Brain _brain;
		[SerializeField] private int _priority;
        [SerializeField] private bool _closingDoors = true;
		[SerializeField] private float _maxSpeed = 4f;
		[SerializeField] private float _acceleration = 1;
		[SerializeField] private float _soppingDistance = 0.5f;
		[SerializeField] private bool _triggered = false;
        [SerializeField] private UnityEvent _ended;

		private FactorInfo _info;
        public int Priority 
        { 
            get => _priority; 
            set => _priority = value; 
        }

		public NavMeshAgent Agent => _agent;
		public FactorInfo Info => _info;

        public virtual void OnBegin() 
        {
            _opener.ClosingDoors = _closingDoors;
			_agent.speed = _maxSpeed;
			_agent.acceleration = _acceleration;
			_agent.stoppingDistance = _soppingDistance;
			_brain.Triggered.Value = _triggered;
		}
        public virtual void OnUpdate() { }       
        public virtual void OnCancel() 
        {
			_brain.Triggered.Value = false;
            _ended.Invoke();
		}
        public virtual void OnTakeNewInfo(FactorInfo info) 
        {
            _info = info;
        }

        public void AddPriority(int value)
        {
            _priority += value;
        }
    }
}