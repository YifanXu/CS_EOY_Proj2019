using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Internals;

public class Animatttoorr : MonoBehaviour
{
    public float jumpForce = 10f;
    public float verticalSize = 0.7f;
    public float horizontalSize = 1f;
    public bool canDI = true;
    public bool isFrozen = false;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    public float spd = 10f;

    public Animator anim;
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
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveL = KeyBinding.GetKey(Control.MoveLeft);
        moveR = KeyBinding.GetKey(Control.MoveRight);
        jumpButton = KeyBinding.GetKey(Control.Jump);
    }

    private void Update()
    {
        var bounds = this.GetComponent<Collider2D>().bounds;
        var center = bounds.center;
        var size = bounds.size;
        isGrounded = Physics2D.OverlapArea(
                new Vector2(center.x - size.x / 2f, center.y - size.y / 2f),
                new Vector2(center.x + size.x / 2f, center.y + size.y / 2f + 0.01f),
                groundLayer
                );
        if (Input.GetKeyUp(moveR)) anim.SetFloat("spd", 6.0f);
        if (Input.GetKeyUp(moveL)) anim.SetFloat("spd", 0.0f);
        if (isGrounded)
        {
            anim.SetBool("isInAir", true);
        }
        else
        {
            anim.SetBool("isInAir", false);
        }

        if (Input.GetKeyDown(moveL)) anim.SetFloat("spd",6.0f);
        
        if (Input.GetKeyDown(moveR)) anim.SetFloat("spd", 6.0f);

    }
}
