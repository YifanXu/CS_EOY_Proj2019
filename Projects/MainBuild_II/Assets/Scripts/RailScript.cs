using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class RailScript : Output
    {
        public Vector2[] vertices;
        public int initialVertex = 0;
        public float spd = 3f;
        public float distanceLimit = 0.3f;

        public int nextVertex;

        // Start is called before the first frame update
        void Start()
        {
            nextVertex = (initialVertex + 1) % vertices.Length;
        }

        // Update is called once per frame
        void Update()
        {
            if (isActive && !UIScript.Ended)
            {
                if (Vector2.Distance(transform.position, vertices[nextVertex]) < distanceLimit)
                {
                    Debug.Log("Turn");
                    nextVertex = (nextVertex + 1) % vertices.Length;
                }
                //Move
                var deltaPos = vertices[nextVertex] - (Vector2)transform.position;
                deltaPos.Normalize();
                deltaPos *= spd * Time.deltaTime;
                Debug.Log(deltaPos);
                transform.position += (Vector3)deltaPos;
            }
            else Debug.Log($"ENDED! isActive={isActive}, UIScript={UIScript.Ended}");
    }

        public override void Trigger()
        {
            isActive = !isActive;
        }
    }
}
