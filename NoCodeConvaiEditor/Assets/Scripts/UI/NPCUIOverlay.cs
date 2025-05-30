using UnityEngine;

public class NPCUIOverlay : MonoBehaviour
{
    [SerializeField] private GameObject movementPanel;

    private void Update()
    {
        movementPanel.SetActive(NPCSelector.Instance.selectedNPC != null);
    }
}
