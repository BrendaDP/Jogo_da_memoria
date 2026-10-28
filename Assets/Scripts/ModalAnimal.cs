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
        "O leão é conhecido como o rei da selva! Ele vive principalmente na África e gosta de viver em grupos. O macho tem uma juba ao redor da cabeça.",
        leao
    );
}

public void AbrirCanguru()
{
    AbrirModal(
        "Canguru",
        "O canguru é um animal que vive na Austrália! Ele tem pernas fortes e adora dar grandes saltos. A mamãe canguru carrega seu filhote em uma bolsinha na barriga.",
        canguru
    );
}

public void AbrirCavalo()
{
    AbrirModal(
        "Cavalo",
        "O cavalo gosta de comer capim e outras plantas. Ele pode correr muito rápido e tem uma crina bonita. Seus filhotes são chamados de potros.",
        cavalo
    );
}

public void AbrirCoelho()
{
    AbrirModal(
        "Coelho",
        "O coelho tem orelhas compridas e adora dar pulinhos. Ele gosta de comer capim, folhas e outros vegetais. Suas pernas fortes ajudam a pular bem rápido.",
        coelho
    );
}

public void AbrirGaviao()
{
    AbrirModal(
        "Gavião",
        "O gavião é uma ave que voa bem alto pelo céu. Ele tem uma visão muito boa e consegue enxergar suas presas de longe. Suas garras fortes ajudam a pegar seu alimento.",
        gaviao
    );
}

public void AbrirPeixe()
{
    AbrirModal(
        "Peixe",
        "Os peixes vivem na água e usam suas nadadeiras para nadar. Eles respiram debaixo d'água usando as brânquias. Existem peixes de muitas cores, tamanhos e formas diferentes.",
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