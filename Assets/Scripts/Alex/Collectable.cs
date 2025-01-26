using System;
using UnityEngine;

public enum CollectableType
{
    Coins,
    Fosil,
    Pearl,
    Diamond,
    Chest
}

public class Collectable : MonoBehaviour
{
    [SerializeField] private CollectableController collectableController;
    [SerializeField] private CollectableType collectableType;

    #region OnCollision functions

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (this.collectableType == CollectableType.Chest) return;

            collectableController.Collect(collectableType);
            Destroy(gameObject);
        }
    }

    #endregion

    #region Interact function
    
    public void Interact()
    {
        collectableController.Collect(collectableType);
        if (this.collectableType == CollectableType.Chest) return;
        Destroy(gameObject);
    }

    #endregion
}
