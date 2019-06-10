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
        public float speed;
        public float rotateAngle;
        public float shootAngle;

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
    }
}
