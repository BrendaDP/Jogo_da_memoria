using UnityEngine;
using TMPro;

public class Carta : MonoBehaviour
{
    public GameObject imagemBicho;
    public GameObject imagemInterrogacao;
    public TMP_Text nomeAnimal;

    private bool virada = false;

    private void Start()
    {
        // Começa mostrando o ?
        virada = false;

        imagemInterrogacao.SetActive(true);
        imagemBicho.SetActive(false);
        nomeAnimal.gameObject.SetActive(false);
    }

    public void Virar()
    {
        // Não deixa clicar enquanto o jogo estiver verificando duas cartas
        if (JogoMemoria.bloqueado)
            return;

        // Não deixa virar novamente uma carta que já está virada
        if (virada)
            return;

        virada = true;

        // Esconde o ?
        imagemInterrogacao.SetActive(false);

        // Mostra a imagem
        imagemBicho.SetActive(true);

        // Mostra o nome
        nomeAnimal.gameObject.SetActive(true);

        // Coloca a imagem e o nome na frente
        imagemBicho.transform.SetAsLastSibling();
        nomeAnimal.transform.SetAsLastSibling();

        // Avisa o jogo que uma carta foi virada
        JogoMemoria.CartaVirada(this);
    }

    public void Desvirar()
    {
        virada = false;

        // Mostra o ?
        imagemInterrogacao.SetActive(true);

        // Esconde a imagem
        imagemBicho.SetActive(false);

        // Esconde o nome
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