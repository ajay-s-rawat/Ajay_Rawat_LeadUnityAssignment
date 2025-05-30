// Core/PersonaRegistry.cs
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PersonaRegistry", menuName = "Convai/Persona Registry")]
public class PersonaRegistry : ScriptableObject
{
    public List<PersonaData> personas;

    public GameObject GetPrefabByCharacterID(string characterID)
    {
        foreach (var persona in personas)
        {
            if (persona.characterID == characterID)
                return persona.npcPrefab;
        }

        Debug.LogError($"[PersonaRegistry] No prefab found for character ID: {characterID}");
        return null;
    }

    public PersonaData GetPersonaByID(string characterID)
    {
        return personas.Find(p => p.characterID == characterID);
    }
}
