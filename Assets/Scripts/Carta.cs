using UnityEngine;
using TMPro;

public class Carta : MonoBehaviour
{
    public GameObject imagemBicho;
    public GameObject imagemInterrogacao;
    public TMP_Text nomeAnimal;

    [Header("Configuração inicial")]
    public bool comecarViradaParaCima = false;

    private bool virada = false;

    private void Start()
    {
        // Define como a carta deve aparecer ao iniciar a cena.
        virada = comecarViradaParaCima;

        if (comecarViradaParaCima)
        {
            // Mostra o animal e o nome.
            imagemInterrogacao.SetActive(false);
            imagemBicho.SetActive(true);
            nomeAnimal.gameObject.SetActive(true);

            imagemBicho.transform.SetAsLastSibling();
            nomeAnimal.transform.SetAsLastSibling();
        }
        else
        {
            // Mantém o comportamento original do jogo da memória.
            imagemInterrogacao.SetActive(true);
            imagemBicho.SetActive(false);
            nomeAnimal.gameObject.SetActive(false);
        }
    }

    public void Virar()
    {
        // Não deixa clicar enquanto o jogo verifica duas cartas.
        if (JogoMemoria.bloqueado)
            return;

        // Não deixa virar novamente uma carta já virada.
        if (virada)
            return;

        virada = true;

        // Esconde a interrogação.
        imagemInterrogacao.SetActive(false);

        // Mostra a imagem e o nome.
        imagemBicho.SetActive(true);
        nomeAnimal.gameObject.SetActive(true);

        // Coloca a imagem e o nome na frente.
        imagemBicho.transform.SetAsLastSibling();
        nomeAnimal.transform.SetAsLastSibling();

        // Avisa o jogo que uma carta foi virada.
        JogoMemoria.CartaVirada(this);
    }

    public void Desvirar()
    {
        virada = false;

        // Mostra a interrogação.
        imagemInterrogacao.SetActive(true);

        // Esconde a imagem e o nome.
        imagemBicho.SetActive(false);
        nomeAnimal.gameObject.SetActive(false);
    }

    public string GetNomeAnimal()
    {
        return nomeAnimal.text;
    }

    public bool EstaVirada()
    {
        return virada;
    }
}