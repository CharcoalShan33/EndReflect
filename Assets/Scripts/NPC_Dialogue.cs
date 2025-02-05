using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum InteractionType
{
    Quest,
    Shop,

    Story //

}
[CreateAssetMenu(menuName = "NPC Dialogue")]
public class NPC_Dialogue : ScriptableObject
{
    [Header("Information")]
    public string interactName;
    public Sprite icon; // Story Only

    [Header("Interaction")]
    public bool hasInteracted;

    public InteractionType interactType;

    [Header("Dialogue")]
    [TextArea] public string[] lines;
}
