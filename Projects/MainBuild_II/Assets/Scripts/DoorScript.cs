using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class DoorScript : Output
    {
        Collider2D box;
        public int closedLayer;
        public int openLayer;

        // Start is called before the first frame update
        void Start()
        {
            box = this.GetComponent<Collider2D>();
            box.isTrigger = !box.isTrigger;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public override void Trigger()
        {
            box.isTrigger = !box.isTrigger;
            this.gameObject.layer = box.isTrigger ? openLayer : closedLayer;
            box.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, box.isTrigger ? 0.5f : 1f);
        }
    }
}
