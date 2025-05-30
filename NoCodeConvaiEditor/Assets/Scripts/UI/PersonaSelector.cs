// UI/PersonaSelector.cs
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class PersonaSelector : MonoBehaviour
{
    [Header("UI Reference")]
    [SerializeField] private TMP_Dropdown personaDropdown;

    [Header("Persona Data Source")]
    [SerializeField] private PersonaRegistry personaRegistry;

    public PersonaData CurrentPersona { get; private set; }

    private void Start()
    {
        PopulateDropdown();
        SelectPersona(0); // Default to first
    }

    private void PopulateDropdown()
    {
        personaDropdown.ClearOptions();

        List<TMP_Dropdown.OptionData> options = new();

        foreach (var persona in personaRegistry.personas)
        {
            options.Add(new TMP_Dropdown.OptionData(persona.characterName));
        }

        personaDropdown.AddOptions(options);
        personaDropdown.onValueChanged.AddListener(SelectPersona);
    }

    private void SelectPersona(int index)
    {
        if (index >= 0 && index < personaRegistry.personas.Count)
        {
            CurrentPersona = personaRegistry.personas[index];
            Debug.Log($"[PersonaSelector] Selected: {CurrentPersona.characterName}");
        }
        else
        {
            CurrentPersona = null;
        }
    }
}
