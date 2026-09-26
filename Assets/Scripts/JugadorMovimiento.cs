using UnityEngine;
using UnityEngine.InputSystem;

public class JugadorMovimiento : MonoBehaviour
{
    [SerializeField] private float velocidad = 6f;

    [SerializeField] private Key teclaIzquierda ; //-1
    [SerializeField] private Key teclaDerecha; //1

    [SerializeField] private float limiteIzquierdo = -7.4f;
    [SerializeField] private float limiteDerecho = 7.4f;

    private Rigidbody2D rb;

    private float direccionHorizontal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        direccionHorizontal = 0;

        if (Keyboard.current == null)
        {
            return;
        }

        if (Keyboard.current[teclaDerecha].isPressed)
        {
            direccionHorizontal = 1;
        }

        if (Keyboard.current[teclaIzquierda].isPressed)
        {
            direccionHorizontal = -1;
        }
    }


    private void FixedUpdate()
    {

        Vector2 movimiento =
            Vector2.right *
            direccionHorizontal *
            velocidad *
            Time.fixedDeltaTime;

        Vector2 posicion = rb.position + movimiento;

        posicion.x = Mathf.Clamp(posicion.x, limiteIzquierdo, limiteDerecho);

        rb.MovePosition(posicion);
    }
}
