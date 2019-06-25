using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class BoxBehavior : MonoBehaviour
    {
        public float speed;
        public float rayDistance;
        private Direction direction = Direction.right;
        public Transform groundDetection;
        private RayCollider2D rayCollider;
        private bool movingRight = false;
        // private BoxCollider2D collider;
        private float timeLoss = -5.0f;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            rayCollider = new RayCollider2D(groundDetection.position, rayDistance);
            if (!rayCollider.groundDown.collider)
            {
                if (movingRight)
                {
                    transform.eulerAngles = new Vector3(0.0f, -180.0f, 0.0f);
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                    movingRight = true;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (!GetComponent<PlayerScript>().isFrozen)
                {
                    Destroy(this.gameObject);
                    UIScript.ChangeTime(timeLoss);
                }
            }
        }
    }
}
