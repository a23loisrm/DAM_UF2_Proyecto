using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cofre : MonoBehaviour
{

    [SerializeField] private float tiempoParaTerminar = 2f; // Tiempo antes de cambiar de nivel

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
{

    if (collision.CompareTag("Player"))
    {
        NivelCompletado();  // Marca el nivel como completado
        Invoke("TerminarNivel", tiempoParaTerminar);
    }
}

public void NivelCompletado()
{
    PlayerPrefs.SetInt("NivelCompletado", 1);  // Marca el nivel como completado
    PlayerPrefs.Save();  // Guarda los datos
}

    private void TerminarNivel()
    {
        SceneManager.LoadScene("SeleccionDeNiveles");
    }
}
