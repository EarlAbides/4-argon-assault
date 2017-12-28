using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        var musicPlayers = GameObject.FindObjectsOfType<MusicPlayer>();

        if (musicPlayers.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
