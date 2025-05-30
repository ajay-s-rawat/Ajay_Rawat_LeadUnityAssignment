using UnityEngine;

public class NPCSelector : MonoBehaviour
{
    public static NPCSelector Instance { get; private set; }

    public NPCController selectedNPC;

    private void Awake()
    {
        Instance = this;
    }

    public void SelectNPC(NPCController npc)
    {
        if (selectedNPC != null)
            selectedNPC.Deselect();

        selectedNPC = npc;
        selectedNPC.Select();

        Debug.Log($"[Selector] Selected: {npc.name}");
    }

    public void Deselect()
    {
        if (selectedNPC != null)
            selectedNPC.Deselect();

        selectedNPC = null;
    }

    public void DeleteSelected()
    {
        if (selectedNPC != null)
        {
            Destroy(selectedNPC.gameObject);
            selectedNPC = null;
        }
    }

    public void MoveSelected(Vector3 direction)
    {
        if (selectedNPC != null)
            selectedNPC.MoveBy(direction);
    }
}
