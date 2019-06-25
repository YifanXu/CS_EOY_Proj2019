using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class ShrimpBehavior : MonoBehaviour
    {
        public GameObject shrimpPrefab;

        public float speed;
        public float rotateAngle = 20.0f;
        public float shootAngle;

        private float timeLoss = -5.0f;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 rotation = this.GetComponent<Transform>().eulerAngles;
            rotation.z += rotateAngle;
            this.GetComponent<Transform>().eulerAngles = rotation;

            Vector3 position = this.GetComponent<Transform>().position;
            position.x += speed * Mathf.Cos(shootAngle);
            position.y += speed * Mathf.Sin(shootAngle);
            this.GetComponent<Transform>().position = position;
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
