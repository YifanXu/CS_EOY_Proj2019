using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class OctopusBehavior : MonoBehaviour
    {
        private Vector3 position;

        public float speed;

        private float timeLoss = -5.0f;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            position = this.GetComponent<Transform>().position;
            position.x += speed;
            this.GetComponent<Transform>().position = position;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(this.gameObject);
                UIScript.ChangeTime(timeLoss);
            }
        }
    }
}
