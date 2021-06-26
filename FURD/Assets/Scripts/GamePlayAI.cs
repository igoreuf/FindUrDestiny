using UnityEngine;
using Random = UnityEngine.Random;

public class GamePlayAI
{
    //Rules for spawning over time
    public static float TimeSpawn()
    {
        return 1 + 3 * Mathf.Exp(-0.01f * Score.scoreValue) + Mathf.Pow(0.15f, Score.scoreValue);
    }

    //Rules for spawning geometry of obstacles
    public static Vector3 GeometrySpawn()
    {
        Vector3 geometry = Vector3.one;

        //Making the obstacle less thick
        geometry.z = 0.75f;

        //Generating different object shapes

        float rand = Random.Range(0f, 1f);

        if (rand > 0.8f)
        {
            geometry.y = 2f;
        }
        else if (rand > 0.6f)
        {
            geometry.x = 2f;
        }
        else if (rand > 0.4f)
        {
            geometry.x = 5f;
        }
        else if (rand > 0.2f)
        {
            geometry.y = 5f;
            geometry.x = 2f;
        }
        else
        {
            geometry.x = 5f;
            geometry.y = 2f;
        }

        return geometry;
    }

    //Taking only 3 Spawners into account. Need to fix this later
    public static Vector3 RandomPos(Transform[] listObjects)
    {
        float rand = Random.Range(0f,1f);
        Vector3 randPos;
        //int avgPos = (int)listObjects.Length / 2;
        
        if(rand >= 0.5f)
        {
            randPos = listObjects[1].position;
        } 
        else if (rand >= 0.25f)
        {
            randPos = listObjects[0].position;
        }
        else
        {
            randPos = listObjects[2].position;
        }
        
        return randPos;
    }

    //Rules for spawning geometry of obstacles
    public static float SpeedSpawn()
    {
        return (2 - Mathf.Exp(-0.04f * Score.scoreValue));
    }

    public static GameObject GenerateObject(GameObject obstacle)
    {
        obstacle.transform.localScale = GamePlayAI.GeometrySpawn();
        return obstacle;
    }
}

