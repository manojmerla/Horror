using UnityEngine;
using UnityEngine.SceneManagement;

public class splashmanager : MonoBehaviour
{
    public float spladhduration = 3f;
    public string mainmenuscenename = "mainmenu";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(loadscene), spladhduration);
    }
    void loadscene() {
        SceneManager.LoadScene(mainmenuscenename);
    }
    // Update is called once per frame
    
}
