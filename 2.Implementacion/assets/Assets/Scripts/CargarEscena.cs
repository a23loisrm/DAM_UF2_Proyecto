using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarEscena : MonoBehaviour

{
    [SerializeField] private string nombreEscena;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)  // Si se presiona cualquier tecla
        {
            SceneManager.LoadScene(nombreEscena);  // Cargar la escena "Nivel1"
        }
    }
}
