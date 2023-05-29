using UnityEngine;

public class SalirJuego : MonoBehaviour
{
    public float tiempoEspera = 3f;

    private bool escapePresionado = false;
    private float tiempoEscapePresionado = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escapePresionado = true;
            tiempoEscapePresionado = Time.time;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            escapePresionado = false;
            tiempoEscapePresionado = 0f;
        }

        if (escapePresionado && Time.time - tiempoEscapePresionado >= tiempoEspera)
        {
            SalirDelJuego();
        }
    }

    void SalirDelJuego()
    {
        // Salir del juego
        Application.Quit();
        // Este código solo se ejecutará en el editor del Unity
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
