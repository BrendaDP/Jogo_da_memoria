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
        "LEÃO",
        "O LEÃO É CONHECIDO COMO O REI DA SELVA! ELE VIVE PRINCIPALMENTE NA ÁFRICA. GOSTA DE VIVER EM GRUPOS, E O MACHO TEM UMA JUBA AO REDOR DA CABEÇA.",
        leao
    );
}

public void AbrirCanguru()
{
    AbrirModal(
        "CANGURU",
        "O CANGURU É UM ANIMAL ORIGINÁRIO DA AUSTRÁLIA! ELE TEM PERNAS FORTES E ADORA DAR GRANDES SALTOS. A MAMÃE CANGURU CARREGA SEU FILHOTE EM UMA BOLSINHA NA BARRIGA.",
        canguru
    );
}

public void AbrirCavalo()
{
    AbrirModal(
        "CAVALO",
        "O CAVALO FOI DOMESTICADO HÁ MILHARES DE ANOS NA REGIÃO DA EURÁSIA. ELE GOSTA DE COMER CAPIM E OUTRAS PLANTAS, PODE CORRER MUITO RÁPIDO E TEM UMA CRINA BONITA. SEUS FILHOTES SÃO CHAMADOS DE POTROS.",
        cavalo
    );
}

public void AbrirCoelho()
{
    AbrirModal(
        "COELHO",
        "O COELHO EUROPEU É ORIGINÁRIO DA PENÍNSULA IBÉRICA, ONDE FICAM PAÍSES COMO PORTUGAL E ESPANHA. ELE TEM ORELHAS COMPRIDAS, GOSTA DE COMER PLANTAS E USA SUAS PERNAS FORTES PARA DAR PULINHOS.",
        coelho
    );
}

public void AbrirGaviao()
{
    AbrirModal(
        "GAVIÃO",
        "O GAVIÃO É UMA AVE ENCONTRADA EM VÁRIAS PARTES DO MUNDO, INCLUSIVE NO BRASIL! ELE VOA ALTO, TEM UMA VISÃO MUITO BOA E USA SUAS GARRAS FORTE PARA CAPTURAR SEU ALIMENTO.",
        gaviao
    );
}

public void AbrirPeixe()
{
    AbrirModal(
        "PEIXE",
        "OS PEIXES VIVEM EM RIOS, LAGOS E MARES DE TODO O MUNDO, INCLUSIVE NO BRASIL! ELES USAM AS NADADEIRAS PARA NADAR E AS BRÂNQUIAS PARA RESPIRAR DEBAIXO D'ÁGUA. EXISTEM PEIXES DE MUITAS CORES, TAMANHOS E FORMAS DIFERENTES.",
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