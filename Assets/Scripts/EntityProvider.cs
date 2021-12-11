namespace Victor.Agents
{
    using System.Collections.Generic;
    using Enteties;
    using UnityEngine;

    public class EntityProvider : MonoBehaviour
    {
        public List<IEntity> entities = new List<IEntity>();
    }
}