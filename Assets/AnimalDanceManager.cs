using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDanceManager : MonoBehaviour
{
    private static List<AnimalDance> animals = new List<AnimalDance>(100);

    public static void Register(AnimalDance animal)
    {
        if (!animals.Contains(animal))
            animals.Add(animal);
    }

    public static void Unregister(AnimalDance animal)
    {
        animals.Remove(animal);
    }

    public static void TriggerAllDances()
    {
        foreach (AnimalDance animal in animals)
        {
            if (animal != null)
                animal.TriggerDance();
        }
    }
}
