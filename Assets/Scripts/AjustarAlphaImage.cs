using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AjustarAlphaImage : MonoBehaviour
{
    public Image imagen;
    public float duracionTransicion = 1f;

    private Color colorNegro = new Color(0f, 0f, 0f, 1f);
    private Color colorTransparente = new Color(0f, 0f, 0f, 0f);

    void Start()
    {
        // Hacer que la imagen sea visible al iniciar
        imagen.color = colorTransparente;

        // Iniciar el fundido a negro
        StartCoroutine(FundidoNormal()); 
    }

    private System.Collections.IEnumerator FundidoNegro()
    {
        float tiempoPasado = 0f;

        while (tiempoPasado < duracionTransicion)
        {
            tiempoPasado += Time.deltaTime;

            float t = tiempoPasado / duracionTransicion;
            imagen.color = Color.Lerp(colorTransparente, colorNegro, t);

            yield return null;
        }

        imagen.color = colorNegro;

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private System.Collections.IEnumerator FundidoNormal()
    {
        float tiempoPasado = 0f;

        while (tiempoPasado < duracionTransicion)
        {
            tiempoPasado += Time.deltaTime;

            float t = tiempoPasado / duracionTransicion;
            imagen.color = Color.Lerp(colorNegro, colorTransparente, t);

            yield return null;
        }


        imagen.color = colorTransparente;

    

    }

    // Función para iniciar el fundido a negro desde otro script, por ejemplo
    public void IniciarFundidoNegro()
    {
        StartCoroutine(FundidoNegro());
    }

    // Función para iniciar el fundido al color normal desde otro script, por ejemplo
    public void IniciarFundidoNormal()
    {
        StartCoroutine(FundidoNormal());
    }
}
