using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Instancia única

    private int monedas = 0;
    [SerializeField] private TextMeshProUGUI txtMonedas;

    private int vidas = 5;
    [SerializeField] private TextMeshProUGUI txtVidas;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;  // Asigna esta instancia como la única
            DontDestroyOnLoad(gameObject); // Mantener GameManager entre escenas
            CargarDatos(); // Cargar datos al inicio
            Debug.Log("GameManager creado y persistente.");
        }
        else
        {
            Debug.Log("GameManager duplicado destruido.");
            Destroy(gameObject);  // Si ya existe un GameManager, eliminar este duplicado
        }
    }

    void Start()
    {
        // Esperar hasta que los textos de UI estén disponibles
        BuscarTextosUI(); // Buscar textos de UI en la escena actual
        ActualizarUI(); // Actualizar la UI al inicio
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Buscar los textos de UI después de que se haya cargado una nueva escena
        BuscarTextosUI();
        ActualizarUI(); // Actualizar la UI después de cargar una nueva escena
    }

    public void SumarMoneda()
    {
        monedas++;
        if (monedas >= 50)
        {
            SumarVida();
            monedas = 0;
        }
        ActualizarUI();
        GuardarDatos();
    }

    public void RestarVida()
    {
        vidas--;
        ActualizarUI();

        if (vidas <= 0)
        {
            SceneManager.LoadScene("SeleccionDeNiveles");
            Reiniciar();
        }
        GuardarDatos();
    }

    public void SumarVida()
    {
        vidas++;
        ActualizarUI();
        GuardarDatos();
    }

    public void Reiniciar()
    {
        monedas = 0;
        vidas = 5;
        ActualizarUI();
        GuardarDatos();
    }

    public int GetVidas()
    {
        return vidas;
    }

    public int GetMonedas()
    {
        return monedas;
    }

    private void ActualizarUI()
    {
        if (txtMonedas != null)
            txtMonedas.text = "" + monedas;
        if (txtVidas != null)
            txtVidas.text = "" + vidas;
    }

    private void GuardarDatos()
    {
        PlayerPrefs.SetInt("Monedas", monedas);
        PlayerPrefs.SetInt("Vidas", vidas);
        PlayerPrefs.Save(); // Guardar en disco
        Debug.Log("Datos guardados: Monedas = " + monedas + ", Vidas = " + vidas);
    }

    private void CargarDatos()
    {
        monedas = PlayerPrefs.GetInt("Monedas", 0); // Cargar monedas (valor por defecto: 0)
        vidas = PlayerPrefs.GetInt("Vidas", 5); // Cargar vidas (valor por defecto: 5)
        Debug.Log("Datos cargados: Monedas = " + monedas + ", Vidas = " + vidas);
    }

    private void BuscarTextosUI()
    {
        // Buscar los textos de UI en la escena actual
        if (txtMonedas == null) 
        {
            txtMonedas = GameObject.Find("TextoMonedas")?.GetComponent<TextMeshProUGUI>();
        }
        if (txtVidas == null) 
        {
            txtVidas = GameObject.Find("TextoVidas")?.GetComponent<TextMeshProUGUI>();
        }
        
        if (txtMonedas != null && txtVidas != null)
        {
            Debug.Log("Textos de UI asignados.");
        }
        else
        {
            Debug.LogError("No se encontraron los textos de UI.");
        }
    }

    // Registrar el método OnSceneLoaded para manejar el cambio de escena
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Asegurarse de desregistrar el método OnSceneLoaded cuando el GameManager se destruye
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnApplicationQuit()
{
    PlayerPrefs.DeleteAll(); // Borra todos los datos guardados
    PlayerPrefs.Save();  // Guarda los cambios (básicamente guarda que no hay datos)
}

}
