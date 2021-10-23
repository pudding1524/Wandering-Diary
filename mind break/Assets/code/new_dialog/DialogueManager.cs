using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Text NameText;
    public Text DialogueText;
    public GameObject StartConversation;
    public GameObject NextConversation;
    private Queue<string> sentences;
    private void Start()
    {
        sentences = new Queue<string>();
        if (StartConversation != null)
        {
            StartConversation.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (dialogue.NextConversation != null)
        {
            NextConversation = dialogue.NextConversation;
        }
        else 
        {
            NextConversation = null;
        }
        NameText.text = dialogue.name;
        DialogueText.fontSize = dialogue.fontsize;
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
            EndDialogue();
        }

        string sentence = sentences.Dequeue();
        DialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        if (NextConversation != null)
        {
            NextConversation.GetComponent<DialogueTrigger>().TriggerDialogue();
        }

        DialogueText.text = "";
    }
}
