using UnityEngine;
using Unity.Cinemachine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private CinemachineCamera cinemachineCamera; // Asigna la cámara virtual en el inspector
    private CinemachineBasicMultiChannelPerlin perlin;
    private float shakeDuration = 0f; // Tiempo restante del shake
    private float shakeIntensity = 0f; // Intensidad del shake

    void Start()
    {
        if (cinemachineCamera != null)
        {
            perlin = cinemachineCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
            if (perlin == null)
            {
                Debug.LogWarning("No se encontró CinemachineBasicMultiChannelPerlin en la cámara.");
            }
        }
        else
        {
            Debug.LogError("CinemachineVirtualCamera no asignada en CameraShaker.");
        }
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            // Reducir el tiempo restante del shake
            shakeDuration -= Time.deltaTime;

            // Si se termina el tiempo, restablece la intensidad
            if (shakeDuration <= 0f && perlin != null)
            {
                perlin.FrequencyGain = 0f;
            }
        }
    }

    public void ShakeCamera(float intensity, float duration)
    {
        if (perlin != null)
        {
            shakeIntensity = intensity;
            shakeDuration = duration;

            // Aplicar intensidad al CinemachineBasicMultiChannelPerlin
            perlin.FrequencyGain = shakeIntensity;
        }
    }
}
