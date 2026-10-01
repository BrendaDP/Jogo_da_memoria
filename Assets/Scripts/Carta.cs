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
        // Não deixa virar se o jogo estiver bloqueando
        if (JogoMemoria.bloqueado)
            return;

        // Inverte o estado da carta
        virada = !virada;

        if (virada)
        {
            // Mostra o animal
            imagemInterrogacao.SetActive(false);
            imagemBicho.SetActive(true);

            // Mostra o nome
            nomeAnimal.gameObject.SetActive(true);

            // Coloca o animal na frente
            imagemBicho.transform.SetAsLastSibling();
            nomeAnimal.transform.SetAsLastSibling();

            // Avisa o jogo que uma carta foi virada
            JogoMemoria.CartaVirada(this);
        }
        else
        {
            Desvirar();
        }
    }

    public void Desvirar()
    {
        virada = false;

        // Volta para o ?
        imagemInterrogacao.SetActive(true);
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