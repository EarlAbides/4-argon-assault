using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 5.0f);
    }
}
