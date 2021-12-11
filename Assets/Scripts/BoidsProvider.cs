namespace Scenes.Scripts
{
    using System.Collections.Generic;
    using UnityEngine;

    public class BoidsProvider : MonoBehaviour
    {
        [SerializeField]
        private List<Agent> agents = new List<Agent>();

        public List<Agent> Agents => agents;

        public void Add(Agent agent)
        {
            agents.Add(agent);
        }
        
        public void Remove(Agent agent)
        {
            agents.Remove(agent);
        }
    }
}