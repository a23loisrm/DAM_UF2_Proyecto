using UnityEngine;

public class Moneda : MonoBehaviour
{

    GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.instance;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))  
        {
            gameManager.SumarMoneda();  
            Destroy(gameObject);  
        }
    }
}
