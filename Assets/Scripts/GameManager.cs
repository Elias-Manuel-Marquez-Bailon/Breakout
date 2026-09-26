using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static event Action<int> AlDestruirLadrillo;

    [SerializeField] private TMP_Text textoPuntos;

    private int puntosJugador = 0;

    private void Start()
    {
        if (textoPuntos == null)
        {
            textoPuntos = FindAnyObjectByType<TMP_Text>();
        }

        AlDestruirLadrillo += SumarPuntos;

        ActualizarPuntos();
    }

    private void OnDestroy()
    {
        AlDestruirLadrillo -= SumarPuntos;
    }

    public static void AnotarLadrillo(int puntos)
    {
        AlDestruirLadrillo?.Invoke(puntos);
    }

    private void SumarPuntos(int puntos)
    {
        puntosJugador += puntos;

        ActualizarPuntos();
    }

    private void ActualizarPuntos()
    {
        if (textoPuntos == null)
        {
            return;
        }

        textoPuntos.text = "Puntos: " + puntosJugador;
    }
}
