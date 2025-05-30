using UnityEngine;
using Convai.Scripts; // Or the namespace SDK uses
using Convai.Scripts.Runtime.Core;

public class NPCController : MonoBehaviour, INPC
{
    [SerializeField] private string characterId;
    private ConvaiNPC convaiNPC;

    private void Awake()
    {
        Debug.Log("Awake");
        convaiNPC = GetComponentInChildren<ConvaiNPC>();
    }

    public void SetPersona(string id, string characterName)
    {
        Debug.Log("SetPersona");
        characterId = id;
        if (convaiNPC != null)
        {
            convaiNPC.characterID = id;
            convaiNPC.characterName = characterName;
        }
    }

    [SerializeField] private Renderer highlightRenderer;

    public void OnMouseDown()
    {
        NPCSelector.Instance.SelectNPC(this);
    }

    public void Select()
    {
        if (highlightRenderer != null)
            highlightRenderer.material.color = Color.yellow;
    }

    public void Deselect()
    {
        if (highlightRenderer != null)
            highlightRenderer.material.color = Color.white;
    }

    public void MoveBy(Vector3 direction)
    {
        transform.position += direction;
    }

    public void StartConversation()
    {
        if (convaiNPC != null)
        {
            // Set this NPC as active in the SDK
            //ConvaiNPC.ActiveConvaiNPC = convaiNPC;
            Debug.Log("[NPC] Set as active Convai NPC: " + characterId); 
        }
    }

}
