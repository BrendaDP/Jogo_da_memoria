
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
            "Maçã",
            "A maçã é uma fruta muito gostosa! Ela pode ser vermelha, verde ou amarela. É crocante, docinha e cresce em árvores chamadas macieiras.",
            maca
        );
    }

    public void AbrirBanana()
    {
        AbrirModal(
            "Banana",
            "A banana é uma fruta muito popular! Ela cresce em cachos e tem uma casca que fica amarela quando está madura. É macia, docinha e fácil de descascar.",
            banana
        );
    }

    public void AbrirLaranja()
    {
        AbrirModal(
            "Laranja",
            "A laranja é uma fruta redondinha e cheia de suco! Sua casca geralmente é alaranjada e seu sabor pode ser doce ou azedinho. Ela também é muito usada para fazer sucos deliciosos.",
            laranja
        );
    }

    public void AbrirMamao()
    {
        AbrirModal(
            "Mamão",
            "O mamão é uma fruta macia e docinha! Por fora, sua casca pode ser verde ou amarelada. Por dentro, sua polpa costuma ser alaranjada e tem pequenas sementinhas pretas.",
            mamao
        );
    }

    public void AbrirUva()
    {
        AbrirModal(
            "Uva",
            "A uva é uma frutinha pequena e redondinha que cresce em cachos. Pode ser verde, roxa ou vermelha. É suculenta e pode ser usada para fazer sucos e geleias.",
            uva
        );
    }

    public void AbrirMelancia()
    {
        AbrirModal(
            "Melancia",
            "A melancia é uma fruta grande e muito refrescante! Por fora, sua casca é verde e, por dentro, sua polpa geralmente é vermelha e cheia de água. Ela é uma delícia nos dias quentes!",
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
