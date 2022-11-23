using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Movement/Direct")]
    [Description("Moves the agent Around the Player")]
    public class RotateAroundPlayer : ActionTask<Transform>
    {
        [RequiredField]
        public BBParameter<GameObject> target;
        public BBParameter<float> speed = 2;
        public BBParameter<float> stopDistance = 2f;
        [Tooltip("-1 or 1 for direction")] public BBParameter<int> LeftRight = 1;
        public BBParameter<float> waitTime = 1f;

        protected override void OnUpdate()
        {
            if (elapsedTime >= waitTime.value)
            {
                EndAction();
            }
            else
            { 
                var offsetPlayer = agent.transform.position - target.value.transform.position;
                var dir = Vector3.Cross(offsetPlayer * LeftRight.value, Vector3.up);
                agent.position = Vector3.MoveTowards(agent.position, agent.position + dir , speed.value * Time.deltaTime);
                var lookPos = target.value.transform.position - agent.transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, rotation, Time.deltaTime * speed.value);
            }
        }
    }
}