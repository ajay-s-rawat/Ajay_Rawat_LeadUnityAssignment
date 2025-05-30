using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PersonaSelector personaSelector;

    public void OnAddNPC()
    {
        if (personaSelector.CurrentPersona != null)
        {
            NPCManager.Instance.SpawnNPC(personaSelector.CurrentPersona);
        }
        else
        {
            Debug.LogWarning("[UIManager] No persona selected.");
        }
    }
}
