using UnityEngine;
using TMPro;

public class Parabens : MonoBehaviour
{
    public TMP_Text tempoFinal;

    private void Start()
    {
        float tempo = JogoMemoria.tempoFinal;

        int minutos = Mathf.FloorToInt(tempo / 60f);
        int segundos = Mathf.FloorToInt(tempo % 60f);

        tempoFinal.text = string.Format("Tempo: {0:00}:{1:00}", minutos, segundos);
    }
}