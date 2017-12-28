using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	#region Designer Properties

	[SerializeField] GameObject deathFX;
	[SerializeField] Transform parent;
	[SerializeField] int pointsPerHit = 15;
	[SerializeField] int hits = 10;

	#endregion

	#region Private Members

	ScoreBoard scoreBoard;

	#endregion

    #region Unity Hooks

    void Start()
    {
		scoreBoard = FindObjectOfType<ScoreBoard>();
        AddNonTriggerBoxCollider();
    }

    void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(pointsPerHit);
        hits--;
        if (hits <= 0)
        {
            BlowUp();
        }
    }

    #endregion

    #region Private Methods

    private void AddNonTriggerBoxCollider()
    {
        var collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    private void BlowUp()
    {
		var fx = Instantiate(deathFX, transform.position, Quaternion.identity);
		fx.transform.parent = parent;


        Destroy(gameObject);
    }

    #endregion
}
