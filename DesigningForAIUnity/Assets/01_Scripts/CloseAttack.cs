using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions
{
    [Category("Movement/Direct")]
    [Description("Moves the agent Around the Player")]
    public class CloseAttack : ActionTask<Transform>
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
               

            }
        }
    }
}
