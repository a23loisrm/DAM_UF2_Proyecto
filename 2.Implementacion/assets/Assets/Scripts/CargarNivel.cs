using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarNivel : MonoBehaviour
{
    [SerializeField] private string nombreNivel; // El nombre del nivel al que se debe cargar
    [SerializeField] private float rangoDeInteraccion = 2f; // Distancia desde el cofre para interactuar
    private bool estaCerca = false;

    void Update()
    {
        // Si el jugador está cerca del cofre y presiona la tecla
        if (estaCerca && (Input.GetKeyDown(KeyCode.E)))
        {
            // Carga la escena especificada
            CargarNivelEscena();
        }
    }

    // Este método detecta cuando el jugador entra en el área del cofre
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Si el objeto que entra es el jugador
        {
            estaCerca = true;  // El jugador está cerca del cofre
        }
    }

    // Este método detecta cuando el jugador sale del área del cofre
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Si el objeto que sale es el jugador
        {
            estaCerca = false;  // El jugador ya no está cerca del cofre
        }
    }

    // Método para cargar el nivel
    private void CargarNivelEscena()
    {
        SceneManager.LoadScene(nombreNivel);  // Carga la escena especificada
    }
}
