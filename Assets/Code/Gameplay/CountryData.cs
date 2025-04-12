using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stores name, image, and fun fact for a country card
[CreateAssetMenu(fileName = "CountryData", menuName = "GeographyGame/Country Data")]
public class CountryData : ScriptableObject
{
    public string countryName;
    public Sprite countryImage;
    [TextArea] public string funFact;
}