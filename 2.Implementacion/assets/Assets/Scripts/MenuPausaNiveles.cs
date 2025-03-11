using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPausaNiveles : MonoBehaviour
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
        // Detectar la pulsación de Escape
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
        // Mostrar el menú de pausa
        pauseMenuUI.SetActive(true);
        isPaused = true;

        // Detener el tiempo en el juego
        Time.timeScale = 0f;
    }

    void ReanudarJuego()
    {
        // Ocultar el menú de pausa
        pauseMenuUI.SetActive(false);
        isPaused = false;

        // Reanudar el tiempo en el juego
        Time.timeScale = 1f;
    }

    // Salir del juego o volver a la selección de niveles
    void SalirDelJuego()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Sale del modo de juego en el editor
        #else
            Application.Quit(); // Cierra la aplicación fuera del editor
        #endif
    }
}
