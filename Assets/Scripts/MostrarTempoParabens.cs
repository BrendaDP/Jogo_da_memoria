
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MostrarTempoParabens : MonoBehaviour
{
    public TMP_Text textoTempo;

    private void Start()
    {
        string cenaAtual = SceneManager.GetActiveScene().name;
        string nomeNivel = "";

        switch (cenaAtual)
        {
            case "Parabens_Animal1":
                nomeNivel = "Animais_Nivel1";
                break;

            case "Parabens_Animal2":
                nomeNivel = "Animais_Nivel2";
                break;

            case "Parabens_Animal3":
                nomeNivel = "Animais_Nivel3";
                break;

            case "Parabens_Animal4":
                nomeNivel = "Animais_Nivel4";
                break;

            case "Parabens_Info":
                nomeNivel = "Animais_Nivel5";
                break;
        }

        if (nomeNivel == "")
        {
            Debug.LogError(
                "Não foi encontrado o nível correspondente à cena: "
                + cenaAtual
            );
            return;
        }

        string chaveTempo = "TempoFinal_" + nomeNivel;

        float tempoFinal = PlayerPrefs.GetFloat(chaveTempo, 0f);

        int minutos = Mathf.FloorToInt(tempoFinal / 60f);
        int segundos = Mathf.FloorToInt(tempoFinal % 60f);

        if (textoTempo != null)
        {
            textoTempo.text = string.Format(
                "Tempo: {0:00}:{1:00}",
                minutos,
                segundos
            );
        }
    }
}
