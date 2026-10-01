using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class JogoMemoria : MonoBehaviour
{
    public TMP_Text temporizador;
    private static float tempo = 0f;
    public static float tempoFinal = 0f;
    private static Carta primeiraCarta;
    private static Carta segundaCarta;

    public static bool bloqueado = false;


    // ==========================================
    // SORTEAR AS POSIÇÕES DAS CARTAS
    // ==========================================

    private void Start()
    {
        tempo = 0f;
        temporizador.text = "Tempo: 00:00";

        Carta[] cartas = FindObjectsByType<Carta>(FindObjectsSortMode.None);

        Vector2[] posicoes = new Vector2[cartas.Length];

        // Guarda as posições originais
        for (int i = 0; i < cartas.Length; i++)
        {
            RectTransform rect = cartas[i].GetComponent<RectTransform>();
            posicoes[i] = rect.anchoredPosition;
        }

        // Embaralha as posições
        for (int i = 0; i < posicoes.Length; i++)
        {
            int aleatorio = Random.Range(i, posicoes.Length);

            Vector2 temp = posicoes[i];
            posicoes[i] = posicoes[aleatorio];
            posicoes[aleatorio] = temp;
        }

        // Coloca cada carta em uma posição sorteada
        for (int i = 0; i < cartas.Length; i++)
        {
            RectTransform rect = cartas[i].GetComponent<RectTransform>();
            rect.anchoredPosition = posicoes[i];
        }
    }


    // ==========================================
    // TEMPORIZADOR
    // ==========================================

    private void Update()
    {
        tempo += Time.deltaTime;

        int minutos = Mathf.FloorToInt(tempo / 60f);
        int segundos = Mathf.FloorToInt(tempo % 60f);

        temporizador.text = string.Format("Tempo: {0:00}:{1:00}", minutos, segundos);
    }


    // ==========================================
    // VERIFICAÇÃO DAS CARTAS
    // ==========================================

    public static void CartaVirada(Carta carta)
    {
        if (primeiraCarta == null)
        {
            // Primeira carta
            primeiraCarta = carta;
        }
        else if (segundaCarta == null)
        {
            // Segunda carta
            segundaCarta = carta;

            // Verifica o par
            VerificarPar();
        }
    }


    private static void VerificarPar()
    {
        if (primeiraCarta.GetNomeAnimal() == segundaCarta.GetNomeAnimal())
        {
            // É um par
            Debug.Log("Par encontrado: " + primeiraCarta.GetNomeAnimal());

            // Espera 2 segundos antes de fazer as cartas desaparecerem
            primeiraCarta.StartCoroutine(SumirPar());
        }
        else
        {
            // Não é par
            Debug.Log("Não é par!");

            bloqueado = true;

            primeiraCarta.StartCoroutine(DesvirarCartas());
        }
    }


    // ==========================================
    // ESPERA ANTES DE SUMIR COM O PAR
    // ==========================================

    private static IEnumerator SumirPar()
    {
        // Espera 2 segundos
        yield return new WaitForSeconds(2f);

        // Faz as duas cartas desaparecerem
        primeiraCarta.gameObject.SetActive(false);
        segundaCarta.gameObject.SetActive(false);

        // Limpa as cartas
        primeiraCarta = null;
        segundaCarta = null;


        // Verifica se encontrou todos os pares
        VerificarFimDeJogo();
    }


    // ==========================================
    // DESVIRAR CARTAS QUE NÃO FORMARAM PAR
    // ==========================================

    private static IEnumerator DesvirarCartas()
    {
        // Espera 3 segundos
        yield return new WaitForSeconds(2f);

        primeiraCarta.Desvirar();
        segundaCarta.Desvirar();

        // Limpa as cartas
        primeiraCarta = null;
        segundaCarta = null;

        bloqueado = false;
    }


    // ==========================================
    // VERIFICAR SE O JOGO TERMINOU
    // ==========================================

    private static void VerificarFimDeJogo()
    {
        Carta[] cartas = FindObjectsByType<Carta>(FindObjectsSortMode.None);

        bool terminou = true;

        foreach (Carta carta in cartas)
        {
            if (carta.gameObject.activeSelf)
            {
                terminou = false;
                break;
            }
        }

        if (terminou)
        {
            Debug.Log("Todos os pares encontrados!");

            tempoFinal = tempo;

            SceneManager.LoadScene("Parabens");
        }
    }
}