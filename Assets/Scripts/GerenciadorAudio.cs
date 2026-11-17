
using UnityEngine;
using UnityEngine.Audio;

public class GerenciadorAudio : MonoBehaviour
{
    public static GerenciadorAudio instancia;

    [Header("Audio Mixer")]
    public AudioMixer audioMixer;

    [Header("Musica")]
    public AudioSource fonteMusica;
    public AudioClip musicaFundo;

    [Header("Efeitos Sonoros")]
    public AudioSource fonteEfeitos;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (fonteMusica != null && musicaFundo != null)
        {
            fonteMusica.clip = musicaFundo;
            fonteMusica.loop = true;
            fonteMusica.Play();
        }
    }

    public void TocarEfeito(AudioClip efeito)
    {
        if (fonteEfeitos != null && efeito != null)
        {
            fonteEfeitos.PlayOneShot(efeito);
        }
    }
}
