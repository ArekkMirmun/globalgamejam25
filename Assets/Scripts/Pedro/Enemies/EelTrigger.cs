using UnityEngine;

public class EelTrigger : MonoBehaviour
{
    public Eel parentEel;
    public Transform movementPoint;

    void Start()
    {
        // Obtener referencia al padre y al punto de movimiento
        parentEel = GetComponentInParent<Eel>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && parentEel != null)
        {
            parentEel.StartMoving();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && parentEel != null)
        {
            parentEel.StopMoving();
        }
    }
}
