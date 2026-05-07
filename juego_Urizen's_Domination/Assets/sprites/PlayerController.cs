using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        // Movimiento
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // Animación caminar
        anim.SetFloat("Speed", Mathf.Abs(move));

        // Girar personaje
        GetComponent<SpriteRenderer>().flipX = move < 0;

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // ⚔ ATAQUE (CLICK IZQUIERDO)
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
