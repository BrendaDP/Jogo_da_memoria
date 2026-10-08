using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class JogoMemoria : MonoBehaviour
{
    public TMP_Text temporizador;

    private static float tempo = 0f;
    private float tempoInicial = 0f;

    public static float tempoFinal = 0f;

    private static Carta primeiraCarta;
    private static Carta segundaCarta;

    public static bool bloqueado = false;


    // ==========================================
    // INICIAR JOGO
    // ==========================================

    private void Start()
    {
        tempoInicial = Time.realtimeSinceStartup;
        tempo = 0f;

        if (temporizador != null)
        {
            temporizador.text = "0:00";
        }

        // Limpa as cartas anteriores
        primeiraCarta = null;
        segundaCarta = null;
        bloqueado = false;


        // ==========================================
        // SORTEAR AS POSIÇÕES DAS CARTAS
        // ==========================================

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
        if (temporizador == null)
            return;

        // Usa tempo real
        tempo = Time.realtimeSinceStartup - tempoInicial;

        int minutos = Mathf.FloorToInt(tempo / 60f);
        int segundos = Mathf.FloorToInt(tempo % 60f);

        temporizador.text = string.Format("{0}:{1:00}", minutos, segundos);
    }


    // ==========================================
    // CARTA FOI VIRADA
    // ==========================================

    public static void CartaVirada(Carta carta)
    {
        if (bloqueado)
            return;

        if (primeiraCarta == null)
        {
            // Primeira carta
            primeiraCarta = carta;
        }
        else if (segundaCarta == null && carta != primeiraCarta)
        {
            // Segunda carta
            segundaCarta = carta;

            // Bloqueia novos cliques
            bloqueado = true;

            // Verifica o par
            VerificarPar();
        }
    }


    // ==========================================
    // VERIFICAR PAR
    // ==========================================

    private static void VerificarPar()
    {
        string nomePrimeira = primeiraCarta.GetNomeAnimal().Trim();
        string nomeSegunda = segundaCarta.GetNomeAnimal().Trim();

        Debug.Log("Carta 1: " + nomePrimeira);
        Debug.Log("Carta 2: " + nomeSegunda);

        if (nomePrimeira == nomeSegunda)
        {
            // É um par
            Debug.Log("Par encontrado: " + nomePrimeira);

            primeiraCarta.StartCoroutine(SumirPar());
        }
        else
        {
            // Não é par
            Debug.Log("Não é par!");

            primeiraCarta.StartCoroutine(DesvirarCartas());
        }
    }


    // ==========================================
    // ESPERA ANTES DE SUMIR COM O PAR
    // ==========================================

    private static IEnumerator SumirPar()
    {
        yield return new WaitForSeconds(2f);

        // Faz as duas cartas desaparecerem
        primeiraCarta.gameObject.SetActive(false);
        segundaCarta.gameObject.SetActive(false);

        // Limpa as cartas
        primeiraCarta = null;
        segundaCarta = null;

        // Libera o jogo
        bloqueado = false;

        // Verifica se encontrou todos os pares
        VerificarFimDeJogo();
    }


    // ==========================================
    // DESVIRAR CARTAS QUE NÃO FORMARAM PAR
    // ==========================================

    private static IEnumerator DesvirarCartas()
    {
        yield return new WaitForSeconds(2f);

        primeiraCarta.Desvirar();
        segundaCarta.Desvirar();

        // Limpa as cartas
        primeiraCarta = null;
        segundaCarta = null;

        // Libera o jogo
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

            // Guarda o tempo que o jogador levou
            tempoFinal = tempo;

            // Vai para a tela de parabéns
            SceneManager.LoadScene("Parabens");
        }
    }
}