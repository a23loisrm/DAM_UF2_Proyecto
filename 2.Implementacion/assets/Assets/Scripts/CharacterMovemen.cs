using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovemen : MonoBehaviour
{

    [SerializeField] private float andar = 5f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isJumping = false;

    private Vector2 startPosition = new Vector2(-0.53f, 1.54f);

    private SpriteRenderer spriteRenderer;

    private Animator animator;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update(){

        float moveInput = 0;

        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            moveInput = -1;
            spriteRenderer.flipX = true;
            //FlipCharacter(true);
        }
        else if (Input.GetKey("right") || Input.GetKey("d"))
        {
            moveInput = 1;
            spriteRenderer.flipX = false;
            //FlipCharacter(false);
        }

        rb.linearVelocity = new Vector2(moveInput * andar, rb.linearVelocity.y);

        animator.SetBool("isRunning", moveInput != 0 && !isJumping);

        //correr con shitf
        if (Input.GetKey("left shift") || Input.GetKey("right shift"))
        {
            rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
        }

        if ((Input.GetKeyDown("up") || Input.GetKeyDown("w") || Input.GetKey(KeyCode.Space)) && !isJumping)
        {
            isJumping = true;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true); // Activar animación de salto
        }
    }

        
         // Detectar colisión con el suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isJumping = false;
            animator.SetBool("isJumping", false); // Desactivar animación de salto
        }

        if (collision.gameObject.CompareTag("Agua"))
        {
            animator.SetBool("isDead", true);
            GameManager.instance.RestarVida();
            if (GameManager.instance.GetVidas() <= 0)
            {
                
                SceneManager.LoadScene("SeleccionDeNiveles"); 
            }
            else
            {
                Respawn();
            }
        }

    }

    public void Respawn()
    {
        transform.position = startPosition; // Mueve al personaje a la posición inicial
        rb.linearVelocity = Vector2.zero; // Detiene cualquier movimiento
    }

}


