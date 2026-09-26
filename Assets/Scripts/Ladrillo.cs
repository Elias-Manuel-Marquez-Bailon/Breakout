using UnityEngine;

public class Ladrillo : MonoBehaviour
{
    [SerializeField] private int puntos = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D cuerpo = collision.collider.attachedRigidbody;

        if (cuerpo == null)
        {
            return;
        }

        if (cuerpo.bodyType == RigidbodyType2D.Kinematic)
        {
            return;
        }

        GameManager.AnotarLadrillo(puntos);

        Destroy(gameObject);
    }
}
