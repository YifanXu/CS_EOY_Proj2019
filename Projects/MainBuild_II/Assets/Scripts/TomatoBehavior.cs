using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class TomatoBehavior : MonoBehaviour
    {
        public GameObject player;
        public Sprite explosion;

        private float distance;
        public float btwDistance = 7.0f;
        public Vector2 forceVector = new Vector2(100.0f, 300.0f);
        private bool active = false;
        private float timer = 0.0f;
        public float explode = 0.2f;

        private float timeLoss = -5.0f;

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
                    this.GetComponent<Rigidbody2D>().AddForce(forceVector);
                }
            }

            if (this.GetComponent<SpriteRenderer>().sprite == explosion)
            {
                Explode();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                this.GetComponent<SpriteRenderer>().sprite = explosion;
            }
        }

        private void Explode()
        {
            timer += Time.deltaTime;
            if (timer >= explode)
            {
                timer = 0.0f;
                Destroy(this.gameObject);
                UIScript.ChangeTime(timeLoss);
            }
        }
    }
}