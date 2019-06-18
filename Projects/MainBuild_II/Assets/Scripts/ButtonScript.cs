using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ButtonScript : MonoBehaviour
    {
        public Sprite pressedSprite;
        public Sprite unPressedSprite;
        public Output[] outputs;
        public LayerMask entityLayer;
        public bool isPressed = false;
        public float delay = 1f;

        private Bounds bounds;
        private SpriteRenderer spriteRen;
        public float timer = 0f;

        // Start is called before the first frame update
        void Start()
        {
            timer = -1f;
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
            if (!isOverlapping && isPressed)
            {
                //Unpress plz
                isPressed = false;
                //Set Timer
                timer = delay;
            }
            else if(isOverlapping && !isPressed)
            {
                isPressed = true;
                if (timer < 0f)
                {
                    //Press
                    TriggerAll();
                    spriteRen.sprite = pressedSprite;
                }
            }

            if (timer >= 0f)
            {
                timer -= Time.deltaTime;
                if(timer < 0f && !isPressed)
                {
                    //Actually unpress
                    TriggerAll();
                    spriteRen.sprite = unPressedSprite;
                }
            }
        }

        private void TriggerAll()
        {
            Debug.Log("TRIGGER!");
            foreach(Output o in outputs)
            {
                o.Trigger();
            }
        }
    }
}