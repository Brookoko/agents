namespace Victor.Agents.Enteties
{
    using System;
    using UnityEngine;

    public class DieAfterTime : MonoBehaviour
    {
        [SerializeField]
        private Entity entity;

        [SerializeField]
        private HitTrigger hitTrigger;

        [SerializeField]
        private float timeWithoutKillToDie;

        private float timer;

        private void Start()
        {
            timer = timeWithoutKillToDie;
            hitTrigger.OnKill += OnKill;
        }

        private void OnKill()
        {
            timer = timeWithoutKillToDie;
        }

        private void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                entity.Die();
                timer = timeWithoutKillToDie;
            }
        }
    }
}
