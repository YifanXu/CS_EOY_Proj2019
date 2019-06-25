using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class RecallAbility : Ability
    {
        private struct Point
        {
            public float time;
            public Vector2 position;

            public Point (float time, Vector2 pos)
            {
                this.time = time;
                this.position = pos;
            }
        }

        public float trailLength = 3f;

        private Queue<Point> trail;
        private float timeSinceStart = 0f;
        private Transform transf;
        private GameObject shadow;

        // Start is called before the first frame update
        void Start()
        {
            this.totalCD = 7f;
            transf = this.GetComponent<Transform>();
            trail = new Queue<Point>();

            //Create Shadow
            shadow = Instantiate(GetComponent<PlayerAbilityScript>().shadowPrefab, transf, true);
        }

        // Update is called once per frame
        void Update()
        {
            timeSinceStart += Time.deltaTime;

            //Record Pos
            trail.Enqueue(new Point(timeSinceStart, transf.position));

            bool dequeued = false;
            Vector3 newPos = transf.position;
            //Delete old positions
            while (trail.Count > 0 && timeSinceStart - trail.Peek().time > trailLength)
            {
                dequeued = true;
                newPos = trail.Dequeue().position;
            }
            if (!dequeued && trail.Count > 0)
            {
                newPos = trail.Peek().position;
            }
            shadow.transform.position = newPos;
            shadow.GetComponent<LineRenderer>().SetPositions(new Vector3[] { transf.position, newPos });
        }

        public override void Activate()
        {
            Debug.Log($"Transform back to {trail.Peek().position}");
            transf.position = trail.Dequeue().position;
            trail.Clear();
        }
    }
}