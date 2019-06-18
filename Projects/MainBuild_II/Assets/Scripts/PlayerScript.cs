using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Internals;

namespace Assets.Scripts
{
    public class PlayerScript : MonoBehaviour
    {
        public float spd = 10f;
        public float jumpForce = 10f;
        public float verticalSize = 0.7f;
        public float horizontalSize = 1f;
        public bool canDI = true;
        public bool isFrozen = false;
        public LayerMask groundLayer;

        private KeyCode moveL;
        private KeyCode moveR;
        private KeyCode jumpButton;
        private Transform transf;
        private Rigidbody2D rigid;
        private SpriteRenderer spriteRen;

        public bool isGrounded = false;
        public bool hitWallRight = false;
        public bool hitWallLeft = false;
        public float momentum = 0f;
        private float momentumDelta = 0f;

        // Start is called before the first frame update
        void Start()
        {
            moveL = KeyBinding.GetKey(Control.MoveLeft);
            moveR = KeyBinding.GetKey(Control.MoveRight);
            jumpButton = KeyBinding.GetKey(Control.Jump);
            transf = this.GetComponent<Transform>();
            rigid = this.GetComponent<Rigidbody2D>();
            spriteRen = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            var bounds = this.GetComponent<Collider2D>().bounds;
            var center = bounds.center;
            var size = bounds.size;
            //Collide?
            isGrounded = Physics2D.OverlapArea(
                new Vector2(center.x - size.x/2f, center.y - size.y/2f),
                new Vector2(center.x + size.x/2f, center.y + size.y/2f + 0.01f),
                groundLayer
                );
            hitWallRight = Physics2D.OverlapArea(
                new Vector2(center.x, center.y - size.y/4f),
                new Vector2(center.x + size.x/2f + 0.01f, center.y + size.y/4f),
                groundLayer
                );
            hitWallLeft = Physics2D.OverlapArea(
                new Vector2(center.x - size.x/2f - 0.01f, center.y - size.y/4f),
                new Vector2(center.x, center.y + size.y/4f),
                groundLayer
                );

            UpdatePosition();
        }

        private void UpdatePosition()
        {
            if (Input.GetKeyDown(moveL)) momentumDelta -= spd;
            if (Input.GetKeyUp(moveL))   momentumDelta += spd;
            if (Input.GetKeyDown(moveR)) momentumDelta += spd;
            if (Input.GetKeyUp(moveR))   momentumDelta -= spd;

            if (canDI || isGrounded)
            {
                momentum += momentumDelta;
                momentumDelta = 0f;
            }
            if (!isFrozen && !(momentum < 0 && hitWallLeft) && !(momentum > 0 && hitWallRight))
            {
                transf.position += new Vector3(momentum * Time.deltaTime, 0);
                if(momentum != 0f) spriteRen.flipX = momentum < 0f;
            }

            if (isGrounded && Input.GetKeyDown(jumpButton) && !isFrozen)
            {
                rigid.velocity = new Vector2(0, jumpForce);
            }
        }
    }
}