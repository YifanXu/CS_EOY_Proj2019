using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class LeverScript : MonoBehaviour
    {
        public Sprite offSprite;
        public Sprite onSprite;
        public Output[] outputs;
        public LayerMask entityLayer;
        public bool activated = false;
        public bool isPressed = false;

        private Bounds bounds;
        private SpriteRenderer spriteRen;

        // Start is called before the first frame update
        void Start()
        {
            bounds = this.GetComponent<Collider2D>().bounds;
            spriteRen = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            var center = bounds.center;
            var size = bounds.size;
            //Collide?
            bool isOverlapping = Physics2D.OverlapArea(
                new Vector2(center.x - size.x / 2f, center.y - size.y / 2f),
                new Vector2(center.x + size.x / 2f, center.y + size.y / 2f + 0.01f),
                entityLayer
                );
            if (isOverlapping && !isPressed)
            {
                //Trigger
                activated = !activated;
                spriteRen.sprite = activated ? onSprite : offSprite;
                TriggerAll();
            }
            isPressed = isOverlapping;
        }

        private void TriggerAll()
        {
            foreach (Output o in outputs)
            {
                o.Trigger();
            }
        }
    }
}