using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public int scoreValue = 0;
    public AudioClip scoreSound;
    private AudioSource audioSource;

    // Update is called once per frame

    private void Start()
    {
        scoreText.text = "0";
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        scoreText.text = scoreValue.ToString();
    }

    public void AddScore()
    {
        scoreValue += 1;
        audioSource.PlayOneShot(scoreSound);
    }
}
