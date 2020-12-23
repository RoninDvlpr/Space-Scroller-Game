using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //singleton
    static Spawner instance;
    public static Spawner Instance
    {
        get
        {
            if (instance == null)
                Debug.Log("Instance of Spawner isn't set!");
                
            return instance;
        }
    }

    //params
    readonly public static float spawningYPosition = 5.1f;

    //lines
    readonly public static int numberOfLines = 4;
    static List<Line> lines;
    public static List<Line> Lines
    {
        get
        {
            if (lines == null)
                SetLines();

            return lines;
        }
    }

    static void SetLines()
    {
        float halfOfScreenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float spacingBetweenLines = halfOfScreenWidth * 2 / (numberOfLines + 1);

        lines = new List<Line>();
        for (int i = 1; i <= numberOfLines; i++)
        {
            lines.Add(Instance.gameObject.AddComponent<Line>()); //adding new line as a component (MonoBehaviour) and storing refference to it in the list
            lines[i-1].lineXPosition = -halfOfScreenWidth + spacingBetweenLines * i;  //setting line's X position
        }
    }

    void Awake()
    {
        SetInstance();
    }

    void SetInstance()
    {
        if (instance == null)
            instance = this;
        else
            Debug.Log("There is two Spawner instances in the scene!");
    }

    public static void SpawnObject(Projectile objectToSpawn, int lineNumber, int numberToSpawn)
    {
        for (int i = 0; i < numberToSpawn; i++)
            Lines[lineNumber].SpawnProjectile(objectToSpawn);
    }

    public static int GetRandomNeighbouringLine(int lineNumber) //return a random line that's a naighbour of given line
    {
        if (lineNumber == 0)
            return 1;
        else if (lineNumber == numberOfLines-1)
            return numberOfLines-2;
        else
            return lineNumber + (1 - 2 * Random.Range(0, 2)); //random neighbouring line
    }
}
