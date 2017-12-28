using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
	# region Designer Variables

    [Tooltip("In Seconds")] [SerializeField] float levelLoadDelay = 1.0f;
    [Tooltip("Death particle effect")] [SerializeField] GameObject deathFX;

	#endregion

	#region Unity Hooks

    void OnTriggerEnter(Collider collider)
    {
        StartDeathSequence();
    }

	#endregion

	#region Private Methods

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");

        if (deathFX != null)
        {
            deathFX.SetActive(true);
        }


        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

	#endregion
}
