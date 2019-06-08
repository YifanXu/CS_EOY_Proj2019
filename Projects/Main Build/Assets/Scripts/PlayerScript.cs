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
        public bool canDI = true;
        public LayerMask groundLayer;

        private KeyCode moveL;
        private KeyCode moveR;
        private KeyCode jumpButton;
        private Transform transf;
        private Rigidbody2D rigid;

        private bool isGrounded = false;
        private float momentum = 0f;
        private float momentumDelta = 0f;

        // Start is called before the first frame update
        void Start()
        {
            moveL = KeyBinding.GetKey(Control.MoveLeft);
            moveR = KeyBinding.GetKey(Control.MoveRight);
            jumpButton = KeyBinding.GetKey(Control.Jump);
            transf = this.GetComponent<Transform>();
            rigid = this.GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            //isGrounded?
            isGrounded = Physics2D.OverlapArea(
                new Vector2(transform.position.x - 0.7f, transform.position.y - 0.7f),
                new Vector2(transform.position.x + 0.7f, transform.position.y + 0.71f),
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
            transf.position += new Vector3(momentum * Time.deltaTime,0);

            if (isGrounded && Input.GetKeyDown(jumpButton))
            {
                rigid.AddForce(new Vector2(0, jumpForce * 100));
            }
        }
    }
}