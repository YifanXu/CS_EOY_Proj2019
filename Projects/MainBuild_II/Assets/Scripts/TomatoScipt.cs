using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class TomatoScipt : MonoBehaviour
    {
        public float force;
        public float angle;
        public GameObject player;
        public float btwDistance;
        private float distance;
        Vector2 forceVector;
        private bool active = false;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            distance = Vector3.Distance(player.transform.position, this.transform.position);

            if (distance <= btwDistance)
            {
                if (!active)
                {
                    Debug.Log("Activated!!");
                    active = true;
                    if ((player.transform.position - this.transform.position).x > 0)
                    {
                        forceVector.x = force * Mathf.Cos(angle);
                    }
                    else
                    {
                        forceVector.x = force * Mathf.Cos(angle) * -1;
                    }
                    forceVector.y = force * Mathf.Sin(angle);
                    this.GetComponent<Rigidbody2D>().AddForce(forceVector);
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                // Explosion Animation
                Destroy(this.gameObject);
                // Kill player somehow
            }
        }
    }
}