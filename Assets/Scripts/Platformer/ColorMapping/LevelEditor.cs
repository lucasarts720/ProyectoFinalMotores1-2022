using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMappings;

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }
    void GenerateTile(int x, int y)
    {

        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            Color pixelColor = map.GetPixel(x, y);
            if (pixelColor.a == 0)
            {
                // los pixeles son transparentes GATO... este texto ignoralo, es solo para explicar lo de abajo UwU
                return;

            } else if (colorMapping.color.Equals(pixelColor))
            {
                Vector2 position = new Vector2(x, y);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
