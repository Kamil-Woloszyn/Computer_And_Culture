using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attached to the CountryCard prefab, stores reference to its data
public class DraggableCountry : MonoBehaviour
{
    public CountryData data;  // Set at spawn time from GameManager
}