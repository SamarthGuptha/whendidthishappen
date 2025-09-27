using UnityEngine;
using TMPro;

public class NoteInteraction : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TextMeshProUGUI interactPromptText;

    private bool playerInRange = false;

    private void Start()
    {
        interactPromptText.enabled = false;
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // The player is in range and has pressed E.
            audioSource.Play();
            interactPromptText.enabled = false;

            // This is the new, more robust part of the code.
            // We disable the script itself, so it will no longer listen for input.
            // The player cannot re-trigger the interaction.
            this.enabled = false;

            // We also disable the collider to prevent any further trigger events.
            GetComponent<Collider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactPromptText.enabled = true;
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactPromptText.enabled = false;
            playerInRange = false;
        }
    }
}