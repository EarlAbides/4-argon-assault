using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	#region Designer Properties

	[SerializeField] GameObject deathFX;
	[SerializeField] Transform parent;

	#endregion

    #region Unity Hooks

    void Start()
    {
        AddNonTriggerBoxCollider();
    }

    void OnParticleCollision(GameObject other)
    {
        BlowUp();
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
