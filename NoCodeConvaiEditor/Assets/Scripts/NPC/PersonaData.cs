// NPC/PersonaData.cs
using UnityEngine;

[CreateAssetMenu(fileName = "PersonaData", menuName = "Convai/Persona", order = 1)]
public class PersonaData : ScriptableObject
{
    public string characterName;
    public string characterID;
    public GameObject npcPrefab;
}
