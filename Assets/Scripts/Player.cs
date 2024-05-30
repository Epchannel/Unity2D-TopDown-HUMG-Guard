using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Điều chỉnh tốc độ
    public float moveSpeed = 5f;
    Vector3 moveInput;

    public float dashBoost;
    public float dashTime;
    private float _dashTime;
    bool isDashing = false;

    // public float rollBoost = 2f;
    // private float rollTime;
    // public float RollTime;
    // bool rollOnce = false;

    private Rigidbody2D rb;
    public Animator animator;

    public SpriteRenderer characterSR;



    // Các phím di chuyển
    // public Vector3 moveInput;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("Roll", true);
        moveInput.x =  Input.GetAxis("Horizontal");
        moveInput.y =  Input.GetAxis("Vertical");

        //Vị trí người chơi + thêm nhân với tốc độ và mượt mà thêm
        transform.position += moveInput * moveSpeed * Time.deltaTime;

        animator.SetFloat("Speed", moveInput.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space) && _dashTime <= 0 && !isDashing == false)
        {
            moveSpeed += dashBoost;
            _dashTime = dashTime;
            isDashing = true;
        }

        if (_dashTime <= 0 && isDashing == true)
        {
            moveSpeed -= dashBoost;
            isDashing = false;
        }
        else
        {
            _dashTime -= Time.deltaTime;
        }


        if (moveInput.x != 0) //Nhân vật khác 0 là đang di chuyển
        {
            if (moveInput.x > 0) //Đang di chuyển sang phải
                characterSR.transform.localScale = new Vector3(1, 1, 0);
            else
                characterSR.transform.localScale = new Vector3(-1, 1, 0); //Quay đầu sang trái
        }
    }
}
