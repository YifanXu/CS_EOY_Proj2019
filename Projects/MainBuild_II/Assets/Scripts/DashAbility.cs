using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class DashAbility : Ability
    {
        public float strength = 10f;
        private TrailRenderer trail;
        private PlayerScript movement;

        public float timer;
        private float trailLinger = 0.2f;
        private float dashTime = 0.1f;
        public float tempMomentumDelta = 0f;

        // Start is called before the first frame update
        void Start()
        {
            trail = gameObject.GetComponent<TrailRenderer>();
            trail.enabled = false;
            movement = gameObject.GetComponent<PlayerScript>();
        }

        // Update is called once per frame
        void Update()
        {
            if(timer > 0f)
            {
                if(tempMomentumDelta != 0f && timer < trailLinger - dashTime)
                {
                    movement.momentum -= tempMomentumDelta;
                    tempMomentumDelta = 0f;
                }
                timer -= Time.deltaTime;
                //trail.time = timer;
            }
            else
            {
                trail.enabled = false;
            }
        }

        public override void Activate()
        {
            if (timer <= trailLinger - dashTime)
            {
                trail.enabled = true;
                trail.time = trailLinger;
                timer = trailLinger;
                tempMomentumDelta = strength * (movement.momentum >= 0f ? 1 : -1);
                movement.momentum += tempMomentumDelta;
            }
        }
    }
}