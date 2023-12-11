using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpookOMeter : MonoBehaviour
{
    private float spookLevel = 0f;

    public void IncreaseSpookLevel()
    {
        spookLevel += 1f; // Voit s‰‰t‰‰ kasvum‰‰r‰‰ tarpeidesi mukaan
        Debug.Log($"Spook-o-meter kasvoi! Uusi taso: {spookLevel}");
        // Voit lis‰t‰ t‰ss‰ muita toimintoja mittarin kasvattamisen yhteydess‰
    }
}
