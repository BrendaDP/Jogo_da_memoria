
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Parabens : MonoBehaviour
{
    public TMP_Text tempoFinal;

    private void Start()
    {
        if (tempoFinal == null)
        {
            Debug.LogError(
                "O campo Tempo Final não está ligado no Inspector!"
            );
            return;
        }

        // Descobre qual nível corresponde à tela de parabéns
        string cenaParabens =
            SceneManager.GetActiveScene().name;

        string cenaNivel = "";

        switch (cenaParabens)
        {
            case "Parabens_Animal1":
                cenaNivel = "Animais_Nivel1";
                break;

            case "Parabens_Animal2":
                cenaNivel = "Animais_Nivel2";
                break;

            case "Parabens_Animal3":
                cenaNivel = "Animais_Nivel3";
                break;

            case "Parabens_Animal4":
                cenaNivel = "Animais_Nivel4";
                break;

            case "Parabens_Animal5":
                cenaNivel = "Animais_Nivel5";
                break;
        }

        if (string.IsNullOrEmpty(cenaNivel))
        {
            Debug.LogError(
                "Não foi encontrado o nível correspondente à cena: "
                + cenaParabens
            );

            tempoFinal.text = "Tempo: 00:00";
            return;
        }

        // Recupera o tempo salvo pelo JogoMemoria.cs
        string chaveTempo = "TempoFinal_" + cenaNivel;

        float tempo = PlayerPrefs.GetFloat(chaveTempo, 0f);

        int minutos = Mathf.FloorToInt(tempo / 60f);
        int segundos = Mathf.FloorToInt(tempo % 60f);

        tempoFinal.text = string.Format(
            "Tempo: {0:00}:{1:00}",
            minutos,
            segundos
        );

        Debug.Log("Cena de parabéns: " + cenaParabens);
        Debug.Log("Nível consultado: " + cenaNivel);
        Debug.Log("Chave consultada: " + chaveTempo);
        Debug.Log("Tempo recuperado: " + tempo);
        Debug.Log("Tempo exibido: " + tempoFinal.text);
    }
}
