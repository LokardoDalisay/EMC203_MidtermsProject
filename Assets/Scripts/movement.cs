using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float horizontal;
    private float speed = 5f;
    private float jumping_power = 8f;
    private bool isFacoingRight = true;

    private bool canDash = true;
    private bool isDashing;
    private float dash_power = 15f;
    private float dash_time = 0.2f; 

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform ground_check;
    [SerializeField] private LayerMask ground_layer;
    public DashManager dm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        horizontal = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumping_power);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && dm.dash_count >= 1)
        {
            StartCoroutine(Dash());
            dm.dash_count--;
        }

        Flip();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(ground_check.position, 0.2f, ground_layer);
    }

    private void Flip()
    {
        if (isFacoingRight && horizontal < 0f || !isFacoingRight && horizontal > 0f)
        {
            isFacoingRight = !isFacoingRight;
            Vector3 local_scale = transform.localScale;
            local_scale.x *= -1f;
            transform.localScale = local_scale;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float original_gravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dash_power, 0f);
        yield return new WaitForSeconds(dash_time);
        rb.gravityScale = original_gravity;
        isDashing = false;
        canDash = true;
    }   
}
