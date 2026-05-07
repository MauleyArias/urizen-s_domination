using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject Contenedor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Contenedor.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void ReanudarBoton()
    {
        Contenedor.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SalirBoton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("menuprincipal");
    }
}
