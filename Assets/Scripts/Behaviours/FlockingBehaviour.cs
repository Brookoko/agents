namespace Scenes.Behaviours
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public abstract class FlockingBehaviour : AgentBehaviour
    {
        public List<Agent> FilteredTargets(Agent agent)
        {
            return Targets.Where(target => (target.Type & agent.Type) != 0).ToList();   
        }
    }
}