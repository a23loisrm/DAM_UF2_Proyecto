using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausa : MonoBehaviour
{
     private bool isPaused = false;  // Estado de la pausa

    [SerializeField] private GameObject pauseMenuUI;  // Referencia al panel de pausa
    [SerializeField] private Button resumeButton;  // Botón de Reanudar
    [SerializeField] private Button exitButton;  // Botón de Salir

    void Start()
    {
        // Asegúrate de que el menú de pausa esté oculto al principio
        pauseMenuUI.SetActive(false);

        // Asignar las funciones a los botones
        resumeButton.onClick.AddListener(ReanudarJuego);
        exitButton.onClick.AddListener(SalirDelJuego);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ReanudarJuego();  
            }
            else
            {
                PausarJuego();  
            }
        }
    }

    void PausarJuego()
    {
        pauseMenuUI.SetActive(true);
        isPaused = true;
    }
    void ReanudarJuego()
    {

        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    // Salir del juego (volver a la selección de niveles)
    void SalirDelJuego()
    {
        // Cargar la escena de selección de niveles
        SceneManager.LoadScene("SeleccionDeNiveles");
    }
}
