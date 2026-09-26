using UnityEngine;

public class PelotaMovimiento : MonoBehaviour 
{

    [SerializeField] private float velocidad = 6f;

    [SerializeField] private Transform paleta;
    [SerializeField] private float alturaSobrePaleta = 0.9f;
    [SerializeField] private float limiteCaida = -5.5f;

    private Rigidbody2D rb;

    private Vector2 posicionInicial;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() 
    {
        posicionInicial = transform.position;

        rb.linearVelocity = DireccionInicial() * velocidad;
    }

    private void Update()
    {
        if (transform.position.y >= limiteCaida)
        {
            return;
        }

        Respawnear();
    }

    private void Respawnear()
    {
        Vector2 puntoRespawn = posicionInicial;

        if (paleta != null)
        {
            puntoRespawn = paleta.position;
            puntoRespawn.y += alturaSobrePaleta;
        }

        rb.linearVelocity = Vector2.zero;
        rb.position = puntoRespawn;

        rb.linearVelocity = DireccionInicial() * velocidad;
    }

    private Vector2 DireccionInicial()
    {
        float xAleatorio = Random.Range(-0.7f, 0.7f);

        return new Vector2(xAleatorio, 1f).normalized;
    }

}
