using UnityEngine;
using UnityEngine.SceneManagement;  // Para cambiar de escena

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;     
    [SerializeField] private float maxHeight = 4f; 
    [SerializeField] private float minHeight = 1f; 

    private Vector3 startPosition; 
    private bool movingUp = true; 

    CharacterMovemen CharacterMovemen;

    void Start()
    {
        startPosition = transform.position;  // Inicializamos la posición de inicio
    }

    void Update()
    {
        // Movimiento del enemigo
        if (movingUp)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            if (transform.position.y >= startPosition.y + maxHeight)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.position -= Vector3.up * speed * Time.deltaTime;
            if (transform.position.y <= startPosition.y + minHeight)
            {
                movingUp = true;
            }
        }
    }

    // Detectar colisión con el jugador
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.RestarVida();

            if (GameManager.instance.GetVidas() <= 0)
            {
                SceneManager.LoadScene("SeleccionDeNiveles");
            }
            else{
                collision.gameObject.GetComponent<CharacterMovemen>().Respawn();
            }
        }
    }
}
