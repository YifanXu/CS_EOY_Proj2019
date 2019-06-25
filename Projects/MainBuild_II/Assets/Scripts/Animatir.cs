using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Internals;


public class Animatir : MonoBehaviour
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
