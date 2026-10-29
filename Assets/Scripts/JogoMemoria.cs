using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class JogoMemoria : MonoBehaviour
{
    public TMP_Text temporizador;

    private static float tempo = 0f;
    private static float tempoInicioRelogio = 0f;
    private static bool temporizadorIniciado = false;

    public static float tempoFinal = 0f;

    private static Carta primeiraCarta;
    private static Carta segundaCarta;

    public static bool bloqueado = false;

    private const string CHAVE_TEMPO = "TempoFinal_";


    // ==========================================
    // INICIAR JOGO
    // ==========================================

    private void Start()
    {
        tempo = 0f;
        tempoFinal = 0f;
        tempoInicioRelogio = 0f;
        temporizadorIniciado = false;

        primeiraCarta = null;
        segundaCarta = null;
        bloqueado = false;

        // Identifica a cena atual.
        string cenaAtual = SceneManager.GetActiveScene().name;

        // Limpa o resultado anterior apenas nas fases do jogo.
        if (
            cenaAtual != "InfoFinal" &&
            cenaAtual != "InfoFinal1" &&
            cenaAtual != "InfoFinal2" &&
            cenaAtual != "InfoFinal3" &&
            cenaAtual != "InfoFinal4"
        )
        {
            PlayerPrefs.SetFloat(CHAVE_TEMPO + cenaAtual, 0f);
            PlayerPrefs.Save();
        }

        if (temporizador != null)
        {
            temporizador.text = "TEMPO 00:00";
        }


        // ==========================================
        // SORTEAR AS POSIÇÕES DAS CARTAS
        // Nas cenas de informações, mantém as posições.
        // ==========================================

        if (
            cenaAtual != "InfoFinal" &&
            cenaAtual != "InfoFinal1" &&
            cenaAtual != "InfoFinal2" &&
            cenaAtual != "InfoFinal3" &&
            cenaAtual != "InfoFinal4"
        )
        {
            Carta[] cartas = FindObjectsByType<Carta>(
                FindObjectsSortMode.None
            );

            Vector2[] posicoes = new Vector2[cartas.Length];

            for (int i = 0; i < cartas.Length; i++)
            {
                RectTransform rect =
                    cartas[i].GetComponent<RectTransform>();

                if (rect != null)
                {
                    posicoes[i] = rect.anchoredPosition;
                }
            }

            // Embaralha as posições.
            for (int i = 0; i < posicoes.Length; i++)
            {
                int aleatorio = Random.Range(i, posicoes.Length);

                Vector2 temp = posicoes[i];
                posicoes[i] = posicoes[aleatorio];
                posicoes[aleatorio] = temp;
            }

            // Aplica as posições sorteadas.
            for (int i = 0; i < cartas.Length; i++)
            {
                RectTransform rect =
                    cartas[i].GetComponent<RectTransform>();

                if (rect != null)
                {
                    rect.anchoredPosition = posicoes[i];
                }
            }
        }
    }


    // ==========================================
    // TEMPORIZADOR
    // ==========================================

    private void Update()
    {
        if (!temporizadorIniciado)
        {
            if (temporizador != null)
            {
                temporizador.text = "TEMPO 00:00";
            }

            return;
        }

        tempo = Time.realtimeSinceStartup - tempoInicioRelogio;

        if (temporizador == null)
            return;

        int minutos = Mathf.FloorToInt(tempo / 60f);
        int segundos = Mathf.FloorToInt(tempo % 60f);

        temporizador.text = string.Format(
            "TEMPO {0:00}:{1:00}",
            minutos,
            segundos
        );
    }


    // ==========================================
    // CARTA FOI VIRADA
    // ==========================================

    public static void CartaVirada(Carta carta)
    {
        if (bloqueado || carta == null)
            return;

        // Inicia o temporizador na primeira carta.
        if (!temporizadorIniciado)
        {
            tempoInicioRelogio = Time.realtimeSinceStartup;
            temporizadorIniciado = true;

            Debug.Log("Temporizador iniciado!");
        }

        if (primeiraCarta == null)
        {
            primeiraCarta = carta;
        }
        else if (segundaCarta == null && carta != primeiraCarta)
        {
            segundaCarta = carta;
            bloqueado = true;

            VerificarPar();
        }
    }


    // ==========================================
    // VERIFICAR PAR
    // ==========================================

    private static void VerificarPar()
    {
        if (primeiraCarta == null || segundaCarta == null)
            return;

        string nomePrimeira =
            primeiraCarta.GetNomeAnimal().Trim();

        string nomeSegunda =
            segundaCarta.GetNomeAnimal().Trim();

        Debug.Log("Carta 1: " + nomePrimeira);
        Debug.Log("Carta 2: " + nomeSegunda);

        if (nomePrimeira == nomeSegunda)
        {
            Debug.Log("Par encontrado: " + nomePrimeira);

            primeiraCarta.StartCoroutine(SumirPar());
        }
        else
        {
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

        if (primeiraCarta != null)
            primeiraCarta.gameObject.SetActive(false);

        if (segundaCarta != null)
            segundaCarta.gameObject.SetActive(false);

        primeiraCarta = null;
        segundaCarta = null;

        bloqueado = false;

        VerificarFimDeJogo();
    }


    // ==========================================
    // DESVIRAR CARTAS QUE NÃO FORMARAM PAR
    // ==========================================

    private static IEnumerator DesvirarCartas()
    {
        yield return new WaitForSeconds(2f);

        if (primeiraCarta != null)
            primeiraCarta.Desvirar();

        if (segundaCarta != null)
            segundaCarta.Desvirar();

        primeiraCarta = null;
        segundaCarta = null;

        bloqueado = false;
    }


    // ==========================================
    // VERIFICAR SE O JOGO TERMINOU
    // ==========================================

    private static void VerificarFimDeJogo()
    {
        Carta[] cartas = FindObjectsByType<Carta>(
            FindObjectsSortMode.None
        );

        bool terminou = true;

        foreach (Carta carta in cartas)
        {
            if (carta.gameObject.activeSelf)
            {
                terminou = false;
                break;
            }
        }

        if (!terminou)
            return;

        Debug.Log("Todos os pares encontrados!");

        // SALVA O TEMPO FINAL.

        if (temporizadorIniciado)
        {
            tempoFinal =
                Time.realtimeSinceStartup - tempoInicioRelogio;
        }
        else
        {
            tempoFinal = 0f;
        }

        tempo = tempoFinal;

        string cenaAtual = SceneManager.GetActiveScene().name;
        string chaveTempo = CHAVE_TEMPO + cenaAtual;

        PlayerPrefs.SetFloat(chaveTempo, tempoFinal);
        PlayerPrefs.Save();

        Debug.Log("Nível concluído: " + cenaAtual);
        Debug.Log("Tempo final salvo: " + tempoFinal);
        Debug.Log("Chave salva: " + chaveTempo);

        // ESCOLHE A CENA DE PARABÉNS DO NÍVEL.

        string cenaParabens = "";

        switch (cenaAtual)
        {
            case "Animais_Nivel1":
                cenaParabens = "Parabens_Animal1";
                break;

            case "Animais_Nivel2":
                cenaParabens = "Parabens_Animal2";
                break;

            case "Animais_Nivel3":
                cenaParabens = "Parabens_Animal3";
                break;

            case "Animais_Nivel4":
                cenaParabens = "Parabens_Animal4";
                break;

            case "Animais_Nivel5":
                cenaParabens = "Parabens_Info";
                break;
        }

        if (cenaParabens != "")
        {
            SceneManager.LoadScene(cenaParabens);
        }
        else
        {
            Debug.LogError(
                "Não foi encontrada uma cena de parabéns para: "
                + cenaAtual
            );
        }
    }
}