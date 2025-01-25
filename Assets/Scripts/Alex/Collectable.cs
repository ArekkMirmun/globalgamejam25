using System;
using UnityEngine;

public enum CollectableType
{
    Coins,
    Fosil,
    Pearl,
    Diamond,
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
            collectableController.Collect(collectableType);
            Destroy(gameObject);
        }
    }

    #endregion

    #region Interact function
    
    public void Interact()
    {
        collectableController.Collect(collectableType);
        Destroy(gameObject);
    }

    #endregion
}
