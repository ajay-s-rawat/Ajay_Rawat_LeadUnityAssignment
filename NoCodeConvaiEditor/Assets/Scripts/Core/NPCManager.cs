// Core/NPCManager.cs
using UnityEngine;
using System.Collections.Generic;

public class NPCManager : Singleton<NPCManager>
{
    [SerializeField] private PersonaRegistry personaRegistry;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform npcParent;

    private List<GameObject> spawnedNPCs = new();

    public void SpawnNPC(PersonaData personaData)
    {
        GameObject selectedPrefab = personaRegistry.GetPrefabByCharacterID(personaData.characterID);

        if (selectedPrefab == null)
        {
            Debug.LogError($"No prefab found for ID: {personaData.characterID}");
            return;
        }

        GameObject npc = Instantiate(selectedPrefab, spawnPoint.position, Quaternion.identity, npcParent);

        INPC npcScript = npc.GetComponent<INPC>();
        if (npcScript == null) Debug.Log("NPCONtroller nahi mil rahi");
        npcScript?.SetPersona(personaData.characterID, personaData.characterName);
        spawnedNPCs.Add(npc);
    }


    public void RemoveLastNPC()
    {
        if (spawnedNPCs.Count > 0)
        {
            GameObject last = spawnedNPCs[^1];
            spawnedNPCs.RemoveAt(spawnedNPCs.Count - 1);
            Destroy(last);
        }
    }

    public void RemoveAllNPCs()
    {
        foreach (var npc in spawnedNPCs)
        {
            Destroy(npc);
        }
        spawnedNPCs.Clear();
    }
}
