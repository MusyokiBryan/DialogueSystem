using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    public List<string> sentences;

    public UnityEvent onSentenceDisplayed;
    public UnityEvent onDialogueFinished;

 public void DisplayNextSentence()
{
    if (sentences.Count == 0)
    {
        onDialogueFinished.Invoke();
        return;
    }

    string sentence = sentences[0];
    sentences.RemoveAt(0);

    onSentenceDisplayed.Invoke();
}

}
