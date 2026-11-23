
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
    // ANIMAIS
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

    // FRUTAS
    case "Parabens_Frutas1":
        cenaNivel = "Frutas_Nivel1";
        break;

    case "Parabens_Frutas2":
        cenaNivel = "Frutas_Nivel2";
        break;

    case "Parabens_Frutas3":
        cenaNivel = "Frutas_Nivel3";
        break;

    case "Parabens_Frutas4":
        cenaNivel = "Frutas_Nivel4";
        break;
    
       case "Parabens_FrutasFinal":
        cenaNivel = "Frutas_Nivel5";
        break;
    
    // OBJETOS
    case "Parabens_Objetos1":
        cenaNivel = "Objetos_Nivel1";
        break;

    case "Parabens_Objetos2":
        cenaNivel = "Objetos_Nivel2";
        break;

    case "Parabens_Objetos3":
        cenaNivel = "Objetos_Nivel3";
        break;

    case "Parabens_Objetos4":
        cenaNivel = "Objetos_Nivel4";
        break;

    case "Parabens_ObjetosFinal":
        cenaNivel = "Objetos_Nivel5";
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
