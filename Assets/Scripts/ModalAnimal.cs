using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModalAnimal : MonoBehaviour
{
    public GameObject painelModal;

    public Image imagemAnimal;
    public TMP_Text nomeAnimal;
    public TMP_Text descricaoAnimal;

    public Sprite leao;
    public Sprite canguru;
    public Sprite cavalo;
    public Sprite coelho;
    public Sprite gaviao;
    public Sprite peixe;

    private void Start()
    {
        // O modal começa fechado
        painelModal.SetActive(false);
    }

public void AbrirLeao()
{
    AbrirModal(
        "Leão",
        "O leão é conhecido como o rei da selva! Ele vive principalmente na África. Gosta de viver em grupos, e o macho tem uma juba ao redor da cabeça.",
        leao
    );
}

public void AbrirCanguru()
{
    AbrirModal(
        "Canguru",
        "O canguru é um animal originário da Austrália! Ele tem pernas fortes e adora dar grandes saltos. A mamãe canguru carrega seu filhote em uma bolsinha na barriga.",
        canguru
    );
}

public void AbrirCavalo()
{
    AbrirModal(
        "Cavalo",
        "O cavalo foi domesticado há milhares de anos na região da Eurásia. Ele gosta de comer capim e outras plantas, pode correr muito rápido e tem uma crina bonita. Seus filhotes são chamados de potros.",
        cavalo
    );
}

public void AbrirCoelho()
{
    AbrirModal(
        "Coelho",
        "O coelho europeu é originário da Península Ibérica, onde ficam países como Portugal e Espanha. Ele tem orelhas compridas, gosta de comer plantas e usa suas pernas fortes para dar pulinhos.",
        coelho
    );
}

public void AbrirGaviao()
{
    AbrirModal(
        "Gavião",
        "O gavião é uma ave encontrada em várias partes do mundo, inclusive no Brasil! Ele voa alto, tem uma visão muito boa e usa suas garras fortes para capturar seu alimento.",
        gaviao
    );
}

public void AbrirPeixe()
{
    AbrirModal(
        "Peixe",
        "Os peixes vivem em rios, lagos e mares de todo o mundo, inclusive no Brasil! Eles usam as nadadeiras para nadar e as brânquias para respirar debaixo d'água. Existem peixes de muitas cores, tamanhos e formas diferentes.",
        peixe
    );
}

    private void AbrirModal(
        string nome,
        string descricao,
        Sprite imagem
    )
    {
        nomeAnimal.text = nome;
        descricaoAnimal.text = descricao;
        imagemAnimal.sprite = imagem;

        painelModal.SetActive(true);
    }

    public void FecharModal()
    {
        painelModal.SetActive(false);
    }
}