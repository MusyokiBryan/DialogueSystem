using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public UnityEvent onDialogueStart;
    public UnityEvent onDialogueEnd;

    private bool playerInRange;

    private DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        playerInRange = false;
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            onDialogueStart.Invoke();
            dialogueManager.StartDialogue(dialogue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            onDialogueEnd.Invoke();
        }
    }
}
