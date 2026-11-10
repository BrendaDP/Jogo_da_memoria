
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModalFrutas : MonoBehaviour
{
    public GameObject painelModal;

    public Image imagemFruta;
    public TMP_Text nomeFruta;
    public TMP_Text descricaoFruta;

    public Sprite maca;
    public Sprite banana;
    public Sprite laranja;
    public Sprite mamao;
    public Sprite uva;
    public Sprite melancia;

    private void Start()
    {
        // O modal começa fechado
        painelModal.SetActive(false);
    }

    public void AbrirMaca()
    {
        AbrirModal(
            "MAÇÃ",
            "A MAÇÃ É UMA FRUTA MUITO GOSTOSA! ELA PODE SER VERMELHA, VERDE OU AMARELA. É CROCANTE, DOCINHA E CRESCE EM ÁRVORES CHAMADAS MACIEIRAS.",
            maca
        );
    }

    public void AbrirBanana()
    {
        AbrirModal(
            "BANANA",
            "A BANANA É UMA FRUTA MUITO POPULAR! ELA CRESCE EM CACHOS E TEM UMA CASCA QUE FICA AMARELA QUANDO ESTÁ MADURA. É MACIA, DOCINHA E FÁCIL DE DESCASCAR.",
            banana
        );
    }

    public void AbrirLaranja()
    {
        AbrirModal(
            "LARANJA",
            "A LARANJA É UMA FRUTA REDONDINHA E CHEIA DE SUCO! SUA CASCA GERALMENTE É ALARANJADA E SEU SABOR PODE SER DOCE OU AZEDINHO. ELA TAMBÉM É MUITO USADA PARA FAZER SUCOS DELICIOSOS.",
            laranja
        );
    }

    public void AbrirMamao()
    {
        AbrirModal(
            "MAMÃO",
            "O MAMÃO É UMA FRUTA MACIA E DOCINHA! POR FORA, SUA CASCA PODE SER VERDE OU AMARELADA. POR DENTRO, SUA POLPA COSTUMA SER ALARANJADA E TEM PEQUENAS SEMENTINHAS PRETAS.",
            mamao
        );
    }

    public void AbrirUva()
    {
        AbrirModal(
            "UVA",
            "A UVA É UMA FRUTINHA PEQUENA E REDONDINHA QUE CRESCe EM CACHOS. PODE SER VERDE, ROXA OU VERMELHA. É SUCULENTA E PODE SER USADA PARA FAZER SUCOS E GELEIAS.",
            uva
        );
    }

    public void AbrirMelancia()
    {
        AbrirModal(
            "MELANCIA",
            "A MELANCIA É UMA FRUTA GRANDE E MUITO REFRESCANTE! POR FORA, SUA CASCA É VERDE E, POR DENTRO, SUA POLPA GERALMENTE É VERMELHA E CHEIA DE ÁGUA. ELA É UMA DELÍCIA NOS DIAS QUENTES!",
            melancia
        );
    }

    private void AbrirModal(
        string nome,
        string descricao,
        Sprite imagem
    )
    {
        nomeFruta.text = nome;
        descricaoFruta.text = descricao;
        imagemFruta.sprite = imagem;

        painelModal.SetActive(true);
    }

    public void FecharModal()
    {
        painelModal.SetActive(false);
    }
}
