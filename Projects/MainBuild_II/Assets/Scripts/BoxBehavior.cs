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
        // private RayCollider2D rayCollider;
        private BoxCollider2D collider;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            //transform.Translate(Vector2.right * speed * Time.deltaTime);
            //rayCollider = new RayCollider2D(groundDetection.position, rayDistance);
            //if (!rayCollider.groundDown.collider && rayCollider.groundLeft.collider)
            //{
            //    transform.eulerAngles = new Vector3(0.0f, 0.0f, -270.0f);
            //}
            //else if
            //    (
            //        (!rayCollider.groundLeft.collider && rayCollider.groundUp.collider) ||
            //        (!rayCollider.groundUp.collider && rayCollider.groundRight.collider) ||
            //        (!rayCollider.groundRight.collider && rayCollider.groundDown.collider)
            //    )
            //{
            //    transform.eulerAngles = new Vector3(0.0f, 0.0f, -90.0f);
            //}

            collider = this.GetComponent<BoxCollider2D>();
            if ( // Bottom is touching
                    Physics2D.OverlapArea
                    (
                        new Vector2
                        (
                            collider.bounds.center.x - (collider.size.x / 2),
                            collider.bounds.center.y - (collider.size.y / 2)
                        ),
                        new Vector2
                        (
                            collider.bounds.center.x + (collider.size.x / 2),
                            collider.bounds.center.y - (collider.size.y / 2)
                        )
                    )
               )
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, -270.0f);
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else if
                ( // Top is touching
                    Physics2D.OverlapArea
                    (
                        new Vector2
                        (
                            collider.bounds.center.x - (collider.size.x / 2),
                            collider.bounds.center.y + (collider.size.y / 2)
                        ),
                        new Vector2
                        (
                            collider.bounds.center.x + (collider.size.x / 2),
                            collider.bounds.center.y + (collider.size.y / 2)
                        )
                    )
               )
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, -270.0f);
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else if
                ( // Left is touching
                    Physics2D.OverlapArea
                    (
                        new Vector2
                        (
                            collider.bounds.center.x - (collider.size.x / 2),
                            collider.bounds.center.y + (collider.size.y / 2)
                        ),
                        new Vector2
                        (
                            collider.bounds.center.x - (collider.size.x / 2),
                            collider.bounds.center.y - (collider.size.y / 2)
                        )
                    )
               )
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, -270.0f);
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else if
                ( // Right is touching
                    Physics2D.OverlapArea
                    (
                        new Vector2
                        (
                            collider.bounds.center.x + (collider.size.x / 2),
                            collider.bounds.center.y + (collider.size.y / 2)
                        ),
                        new Vector2
                        (
                            collider.bounds.center.x + (collider.size.x / 2),
                            collider.bounds.center.y - (collider.size.y / 2)
                        )
                    )
               )
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, -270.0f);
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
    }
}
