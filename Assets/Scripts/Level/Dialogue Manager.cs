using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject storyPanel;
    [SerializeField] GameObject dialoguePanel;

    [SerializeField] Image npcIcon;

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI dialogueText;

    public static DialogueManager instance;

    

    private void Awake() 
    {
        if(instance != this && instance != null)
        {
            Destroy(gameObject);

        }
        else 
        {
            instance = this;
        }
    }
}
