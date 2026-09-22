using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pelotaPrefab;
    [SerializeField] private Transform spawnPelota;

    private int puntosJugador = 0;

    void Start()
    {
        CrearPelota();
    }

    private void CrearPelota()
    {
        Instantiate(
            pelotaPrefab,
            spawnPelota.position,
            Quaternion.identity
        );
    }

    private void puntosJugador() {
        //Aqui digamos que cuando la pelota golpe a un cuadrito, este anote
        //su puntuacion
    }

}
