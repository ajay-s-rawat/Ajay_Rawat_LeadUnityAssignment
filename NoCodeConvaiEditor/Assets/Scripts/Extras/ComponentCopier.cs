// Scripts/EditorTools/ComponentCopier.cs
using UnityEngine;

[ExecuteInEditMode]
public class ComponentCopier : MonoBehaviour
{
    [Header("Drag Source Object Here")]
    public GameObject source;

    [ContextMenu("Copy Components From Source")]
    public void CopyComponentsFromSource()
    {
        if (source == null)
        {
            Debug.LogWarning("No source object assigned.");
            return;
        }

        if (source == this.gameObject)
        {
            Debug.LogWarning("Source and target cannot be the same object.");
            return;
        }

        var sourceComponents = source.GetComponents<Component>();
        foreach (var src in sourceComponents)
        {
            if (src is Transform)
                continue; // Don't copy Transform

            UnityEditorInternal.ComponentUtility.CopyComponent(src);
            UnityEditorInternal.ComponentUtility.PasteComponentAsNew(this.gameObject);
        }

        Debug.Log($"Copied {sourceComponents.Length - 1} components from '{source.name}' to '{this.gameObject.name}'.");
    }
}
