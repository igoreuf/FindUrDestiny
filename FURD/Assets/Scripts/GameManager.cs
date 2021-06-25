using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject obstanceObject;
    public PlayerControllerMobile player;
    public Text messageScreen;
    public Transform[] obstacleSpawners;
    public static bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerMobile>();
        player.enabled = false;
        //player.GetComponent<PlayerController>().enabled = false;
        messageScreen = GameObject.FindGameObjectWithTag("WelcomeMessage").gameObject.GetComponent<Text>();
        messageScreen.enabled = true;
        StartCoroutine(WelcomeScreen());
        Time.timeScale = 1;
        isGameOver = false;
    }

    private void Update()
    {
        if (isGameOver)
        {
            Invoke("GameOverScreen", 1f);
        }
    }

    IEnumerator CreateObstacles(float time)
    {
        while (!isGameOver)
        {
            Vector3 randPos = obstacleSpawners[Random.Range(0, obstacleSpawners.Length)].position;
            Instantiate(obstanceObject, randPos, Quaternion.identity);
            yield return new WaitForSeconds(time);
        }

    }

    void GameOverScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator WelcomeScreen()
    {
        messageScreen.text = "Wecolme!";
        yield return new WaitForSeconds(2f);
        messageScreen.text = "Time to Run!";
        yield return new WaitForSeconds(2f);
        messageScreen.text = "Get Ready!";
        yield return new WaitForSeconds(3f);
        StartCoroutine(CreateObstacles(5f));
        messageScreen.text = "Go!";
        player.enabled = true;
        yield return new WaitForSeconds(2f);
        messageScreen.enabled = false;
    }
}
