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
        public float size = 0.7f;
        public bool canDI = true;
        private float momentum = 0f;
        public LayerMask groundLayer;

        private KeyCode moveL;
        private KeyCode moveR;
        private KeyCode jumpButton;
        private Transform transf;
        private Rigidbody2D rigid;
        private SpriteRenderer spriteRen;

        private bool isGrounded = false;
        public bool hitWallRight = false;
        public bool hitWallLeft = false;
        private float momentumDelta = 0f;

        // Start is called before the first frame update
        void Start()
        {
            moveL = KeyBinding.GetKey(Control.MoveLeft);
            moveR = KeyBinding.GetKey(Control.MoveRight);
            jumpButton = KeyBinding.GetKey(Control.Jump);
            transf = this.GetComponent<Transform>();
            rigid = this.GetComponent<Rigidbody2D>();
            spriteRen = this.GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            //Collide?
            isGrounded = Physics2D.OverlapArea(
                new Vector2(transform.position.x - size, transform.position.y - size),
                new Vector2(transform.position.x + size, transform.position.y + size + 0.01f),
                groundLayer
                );
            hitWallRight = Physics2D.OverlapArea(
                new Vector2(transform.position.x, transform.position.y - size/2f),
                new Vector2(transform.position.x + size + 0.01f, transform.position.y + size/2f),
                groundLayer
                );
            hitWallLeft = Physics2D.OverlapArea(
                new Vector2(transform.position.x - size - 0.01f, transform.position.y - size/2f),
                new Vector2(transform.position.x, transform.position.y + size/2f),
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
            if (!(momentum < 0 && hitWallLeft) && !(momentum > 0 && hitWallRight))
            {
                transf.position += new Vector3(momentum * Time.deltaTime, 0);
                spriteRen.flipY = momentum < 0f;
            }

            if (isGrounded && Input.GetKeyDown(jumpButton))
            {
                rigid.velocity = new Vector2(0, jumpForce);
            }
        }
    }
}