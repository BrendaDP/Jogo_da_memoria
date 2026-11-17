
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModalObjetos : MonoBehaviour
{
    public GameObject painelModal;

    public Image imagemObjeto;
    public TMP_Text nomeObjeto;
    public TMP_Text descricaoObjeto;

    public Sprite relogio;
    public Sprite caneta;
    public Sprite chave;
    public Sprite chapeu;
    public Sprite livro;
    public Sprite cadeira;

    public AudioClip somAbrirModal;

    private void Start()
    {
        // O modal começa fechado
        painelModal.SetActive(false);
    }

    public void AbrirRelogio()
    {
        AbrirModal(
            "RELÓGIO",
            "O RELÓGIO É UM OBJETO QUE USAMOS PARA SABER AS HORAS! ELE PODE FICAR NA PAREDE, NA MESA OU NO PULSO. EXISTEM RELÓGIOS DE VÁRIOS TAMANHOS E MODELOS.",
            relogio
        );
    }

    public void AbrirCaneta()
    {
        AbrirModal(
            "CANETA",
            "A CANETA É UM OBJETO QUE USAMOS PARA ESCREVER E DESENHAR! ELA POSSUI TINTA E PODE TER VÁRIAS CORES, COMO AZUL, PRETA, VERMELHA E VERDE.",
            caneta
        );
    }

    public void AbrirChave()
    {
        AbrirModal(
            "CHAVE",
            "A CHAVE É UM OBJETO QUE USAMOS PARA ABRIR E FECHAR PORTAS E CADEADOS! ELA GERALMENTE É FEITA DE METAL E EXISTE EM DIFERENTES FORMATOS E TAMANHOS.",
            chave
        );
    }

    public void AbrirChapeu()
    {
        AbrirModal(
            "CHAPÉU",
            "O CHAPÉU É UM ACESSÓRIO QUE USAMOS NA CABEÇA! ELE PODE AJUDAR A PROTEGER DO SOL E TAMBÉM FAZ PARTE DE DIFERENTES ESTILOS DE ROUPAS.",
            chapeu
        );
    }

    public void AbrirLivro()
    {
        AbrirModal(
            "LIVRO",
            "O LIVRO É UM OBJETO QUE NOS AJUDA A APRENDER E CONHECER NOVAS HISTÓRIAS! ELE TEM PÁGINAS COM TEXTOS E ILUSTRAÇÕES QUE ESTIMULAM NOSSA IMAGINAÇÃO.",
            livro
        );
    }

    public void AbrirCadeira()
    {
        AbrirModal(
            "CADEIRA",
            "A CADEIRA É UM OBJETO QUE USAMOS PARA SENTAR! ELA PODE SER FEITA DE MADEIRA, PLÁSTICO OU METAL. EXISTEM CADEIRAS DE VÁRIOS FORMATOS E TAMANHOS.",
            cadeira
        );
    }

    private void AbrirModal(
        string nome,
        string descricao,
        Sprite imagem
    )
    {
        nomeObjeto.text = nome;
        descricaoObjeto.text = descricao;
        imagemObjeto.sprite = imagem;

        painelModal.SetActive(true);

        if (GerenciadorAudio.instancia != null)
        {
            GerenciadorAudio.instancia.TocarEfeito(somAbrirModal);
        }
    }

    public void FecharModal()
    {
        painelModal.SetActive(false);
    }
}
