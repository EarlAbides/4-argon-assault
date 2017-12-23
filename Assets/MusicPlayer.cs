using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{	
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start()
    {
        Invoke("LoadFirstLevel", 2.0f);
    }

    void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
}
