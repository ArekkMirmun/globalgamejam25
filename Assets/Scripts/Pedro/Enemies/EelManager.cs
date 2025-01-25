using UnityEngine;

public class EelManager : MonoBehaviour
{
    public Eel[] eels; // Array para almacenar ambas anguilas

    // Método para activar una Eel y desactivar las demás
    public void ActivateEel(Eel activeEel)
    {
        foreach (Eel eel in eels)
        {
            if (eel == activeEel)
            {
                eel.gameObject.SetActive(true); // Activa la Eel actual
            }
            else
            {
                eel.gameObject.SetActive(false); // Desactiva las demás
            }
        }
    }
}
