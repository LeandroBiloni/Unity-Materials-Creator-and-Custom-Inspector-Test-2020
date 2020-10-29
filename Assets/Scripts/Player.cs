using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string[] charName = { "Mage", "Warrior", "Healer" };
    public Dictionary<string, string>[] dictionaryArray = new Dictionary<string, string>[3];
    public Dictionary<string, string> mageDictionary = new Dictionary<string, string>();
    public Dictionary<string, string> warriorDictionary = new Dictionary<string, string>();
    public Dictionary<string, string> healerDictionary = new Dictionary<string, string>();
    public List<Vector3> waypoints = new List<Vector3>();
    public int wpCount = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = waypoints[wpCount];
            wpCount++;
            if (wpCount == waypoints.Count)
                wpCount = 0;
        }
    }
    public void StartDictionary()
    {
        mageDictionary.Add("Mage First Key", "Mage First value");
        mageDictionary.Add("Mage Second Key", "Mage Second value");
        mageDictionary.Add("Mage Third Key", "Mage Third value");
        warriorDictionary.Add("Warrior First Key", "Warrior First value");
        warriorDictionary.Add("Warrior Second Key", "Warrior Second value");
        healerDictionary.Add("Healer First Key", "Healer First value");
        healerDictionary.Add("Healer Second Key", "Healer Second value");
        healerDictionary.Add("Healer Third Key", "Healer Third value");
        healerDictionary.Add("Healer Fourth Key", "Healer Fourth value");
        healerDictionary.Add("Healer Fifth Key", "Healer Fifth value");
        healerDictionary.Add("Healer Sixth Key", "Healer Sixth value");
        dictionaryArray[0] = mageDictionary;
        dictionaryArray[1] = warriorDictionary;
        dictionaryArray[2] = healerDictionary;
    }
}
