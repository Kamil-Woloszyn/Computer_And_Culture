using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactManager : MonoBehaviour
{
    // Set as a Singleton so it can be accessed globally
    public static FactManager Instance;

    // Dictionary of country facts
    private Dictionary<string, string> facts = new Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase)
    {
        { "Ireland", "Ireland is known as the Emerald Isle because it’s so green!" },
        { "France", "France is famous for the Eiffel Tower and yummy croissants!" },
        { "Germany", "Germany has over 1,500 different kinds of sausages!" },
        { "Italy", "Pizza and pasta come from Italy!" },
        { "Spain", "In Spain, people sometimes take a nap in the afternoon called a 'siesta'." },
        { "Japan", "Japan has trains so fast they’re called bullet trains!" },
        { "India", "India has a big festival called Diwali, the festival of lights!" },
        { "America", "The USA has 50 states, and one is called Hawaii—it’s made of islands!" },
        { "Denmark", "Denmark is often called the happiest country in the world!" },
        { "Hungary", "Hungary’s capital, Budapest, has fun river cruises on the Danube." },
        { "Egypt", "Egypt is home to the pyramids, built thousands of years ago!" },
        { "South Africa", "South Africa has 11 official languages!" }
    };

    private void Awake()
    {
        
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    /// <summary>
    /// Function for getting the fact from the country name 
    /// </summary>
    /// <param name="countryName"></param>
    /// <returns></returns>
    public string GetFact(string countryName)
    {
        countryName = countryName.Trim();

        if (facts.TryGetValue(countryName, out string fact))
        {
            return fact;
        }
        else
        {
            Debug.LogWarning($"❗ No fact found for '{countryName}' in FactManager.");
            return "Fact missing. Please ask your teacher to update the FactManager!";
        }
    }
}