//using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trocarcena : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Funcionando...");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void trocarcena(string qualcena)
    {
        SceneManager.LoadScene(qualcena);
    }
}
