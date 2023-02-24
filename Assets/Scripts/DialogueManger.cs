using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    public UnityEvent onDialogueFinished;

    private Queue<string> sentences;
    private Dialogue currentDialogue;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            onDialogueFinished.Invoke();
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        // Display the sentence in the UI
    }

    public void EndDialogue()
    {
        // Hide the dialogue UI
        currentDialogue = null;
    }
}
