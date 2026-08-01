using UnityEngine;

public class Easteregg : MonoBehaviour
{
    [Header("Audio Config")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip soundEffect;

    private void Start()
    {
        // Si no se asignó un AudioSource en el Inspector, busca uno en este GameObject
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void OnMouseDown()
    {
        if (audioSource != null)
        {
            if (soundEffect != null)
            {
                audioSource.PlayOneShot(soundEffect);
            }
            else
            {
                audioSource.Play();
            }
        }
        else
        {
            Debug.LogWarning("No se encontró ningún AudioSource en el objeto " + gameObject.name);
        }
    }
}

