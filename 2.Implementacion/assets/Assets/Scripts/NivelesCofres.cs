using UnityEngine.UI;
using UnityEngine;

public class NivelesCofres : MonoBehaviour
{

    public Sprite cofreCerrado;  // Imagen cuando el nivel está bloqueado
    public Sprite cofreAbierto;  // Imagen cuando el nivel está completado
    private SpriteRenderer cofreImage;    // Referencia al componente Image (para cambiar el sprite)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cofreImage = GetComponent<SpriteRenderer>(); // Obtiene la imagen del cofre
        Update();  // Llama a la función al inicio
    }

    // Update is called once per frame
    void Update()
    {
        int nivelCompletado = PlayerPrefs.GetInt("NivelCompletado", 0); // 0 = No completado, 1 = Completado
        if (nivelCompletado == 1)
        {
            cofreImage.sprite = cofreAbierto;  // Si el nivel se completó, muestra el cofre abierto
        }
        else
        {
            cofreImage.sprite = cofreCerrado;  // Si no, mantiene el cofre cerrado
        }
    }

    
}
