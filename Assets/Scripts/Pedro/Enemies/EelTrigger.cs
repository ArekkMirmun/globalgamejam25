using UnityEngine;

public class EelTrigger : MonoBehaviour
{
    public Eel parentEel;

    void Start()
    {
        // Obtener referencia al padre
        parentEel = GetComponentInParent<Eel>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si el jugador activa el trigger, iniciar el movimiento de la anguila
        if (other.CompareTag("Player") && parentEel != null)
        {
            parentEel.StartMoving();
        }
    }
}
