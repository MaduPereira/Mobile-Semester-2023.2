using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public string animalName; // O nome do animal
    public AudioClip animalSound; // O som do animal
    private AudioSource audioSource; // Componente de �udio

    private void Start()
    {
        // Obt�m o componente de �udio
        audioSource = GetComponent<AudioSource>();

        // Verifica se um som foi atribu�do ao animal
        if (animalSound == null)
        {
            Debug.LogWarning("O som do animal n�o est� configurado para: " + gameObject.name);
        }
    }

    public void PlayAnimalSound()
    {
        if (animalSound != null && audioSource != null)
        {
            // Toca o som do animal
            audioSource.PlayOneShot(animalSound);
        }
    }

    public void StopAnimalSound()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            // Para a reprodu��o do som do animal
            audioSource.Stop();
        }
    }

    public string GetAnimalName()
    {
        return animalName;
    }
}
