using System.Collections.Generic;
using UnityEngine;

public class NPCManager : Singleton<NPCManager>
{
    [Header("Persona Registry")]
    [SerializeField] private PersonaRegistry personaRegistry;

    [Header("Spawn Settings")]
    [SerializeField] private Transform npcParent;
    [SerializeField] private Vector3 spawnAreaCenter = Vector3.zero;
    [SerializeField] private Vector3 spawnAreaSize = new Vector3(10f, 0f, 10f);

    private readonly List<GameObject> spawnedNPCs = new();

    /// <summary>
    /// Spawns an NPC based on the selected persona data at a random position.
    /// </summary>
    public void SpawnNPC(PersonaData personaData)
    {
        GameObject selectedPrefab = personaRegistry.GetPrefabByCharacterID(personaData.characterID);

        if (selectedPrefab == null)
        {
            Debug.LogError($"[NPCManager] No prefab found for ID: {personaData.characterID}");
            return;
        }

        Vector3 spawnPos = GetRandomSpawnPosition();
        GameObject npc = Instantiate(selectedPrefab, spawnPos, Quaternion.identity, npcParent);

        INPC npcScript = npc.GetComponent<INPC>();
        npcScript?.SetPersona(personaData.characterID, personaData.characterName);

        spawnedNPCs.Add(npc);
    }

    /// <summary>
    /// Removes the last NPC spawned.
    /// </summary>
    public void RemoveLastNPC()
    {
        if (spawnedNPCs.Count > 0)
        {
            GameObject last = spawnedNPCs[^1];
            spawnedNPCs.RemoveAt(spawnedNPCs.Count - 1);
            Destroy(last);
        }
    }

    /// <summary>
    /// Removes all NPCs from the scene.
    /// </summary>
    public void RemoveAllNPCs()
    {
        foreach (GameObject npc in spawnedNPCs)
        {
            Destroy(npc);
        }

        spawnedNPCs.Clear();
    }

    /// <summary>
    /// Returns a random spawn position within the defined area.
    /// </summary>
    private Vector3 GetRandomSpawnPosition()
    {
        return spawnAreaCenter + new Vector3(
            Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
            spawnAreaCenter.y,
            Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f)
        );
    }

    /// <summary>
    /// Draw the spawn area in the Scene view.
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(spawnAreaCenter, spawnAreaSize);
    }
}
