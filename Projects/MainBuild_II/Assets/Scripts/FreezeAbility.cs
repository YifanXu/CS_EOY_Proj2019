using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class FreezeAbility : Ability
    {
        public float duration = 3f;
        public float timer;

        private PlayerScript movement;
        private Rigidbody2D rigid;
        private SpriteRenderer spriteRen;

        private Vector2 tempVelocity;
        private float tempGravity;

        // Start is called before the first frame update
        void Start()
        {
            totalCD = 5f;
            movement = this.GetComponent<PlayerScript>();
            rigid = this.GetComponent<Rigidbody2D>();
            spriteRen = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if(timer > 0f)
            {
                timer -= Time.deltaTime;
                Color c = spriteRen.color;
                c.a = 1f - timer / duration * 0.7f;
                spriteRen.color = c;

                if (timer < 0f)
                {
                    movement.isFrozen = false;
                    UIScript.staticObject.isFrozen = false;

                    //Restore movement
                    rigid.velocity = tempVelocity;
                    rigid.gravityScale = tempGravity;

                    //Restore Color
                    spriteRen.color = Color.white;
                }
            }
        }

        public override void Activate()
        {
            timer = duration;
            movement.isFrozen = true;
            UIScript.staticObject.isFrozen = true;

            //Suspend rigid movements
            tempVelocity = rigid.velocity;
            tempGravity = rigid.gravityScale;
            rigid.velocity = new Vector2();
            rigid.gravityScale = 0f;

            //Change Color
            Color c = spriteRen.color;
            c.a = 0f;
            spriteRen.color = c;
        }
    }
}