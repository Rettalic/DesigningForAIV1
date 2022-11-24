using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Movement/Direct")]
    [Description("Moves the agent towards to target per frame without pathfinding")]
    public class AgentMoveTowards : ActionTask<NavMeshAgent>
    {

        [RequiredField]
        public BBParameter<GameObject> target;
        public BBParameter<float> speed = 2;
        public BBParameter<float> stopDistance = 0.1f;
        public bool waitActionFinish;

        protected override void OnUpdate()
        {
            if ((agent.transform.position - target.value.transform.position).magnitude <= stopDistance.value)
            {
                EndAction();
                return;
            }

            agent.SetDestination(target.value.transform.position);
            if (!waitActionFinish)
            {
                EndAction();
            }
        }

    }
}