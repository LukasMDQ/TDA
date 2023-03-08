
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneControler : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        CambiarNivel();
        RegresarNivel();
        ReproducirAudio();
        PausarAudio();

    }
    public void CambiarNivel()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            SceneManager.LoadScene(1);
        }
    }
    public void RegresarNivel()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void ReproducirAudio()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            TestSound.PlayAudio();
        }
    }
    public void PausarAudio()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TestSound.PausarAudio();
        }
    }
}
