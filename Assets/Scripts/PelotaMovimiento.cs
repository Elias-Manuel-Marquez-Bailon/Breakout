using UnityEngine;

public class PelotaMovimiento : MonoBehaviour 
{

    [SerializeField] private float velocidad = 6f;

    private Rigidbody2D rb;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() 
    {
        Vector2 direccionInicial = new Vector2(0.5f, 1);
        direccionInicial = direccionInicial.normalized;
        rb.linearVelocity = direccionInicial * velocidad;

        float xAleatorio = Random.Range(-0.7f, 0.7f); 
        //direccionInicial = new Vector2(xAleatorio, 1f);
    }

}
