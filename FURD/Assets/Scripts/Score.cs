using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue;
    public AudioClip scoreSound;
    private AudioSource audioSource;

    // Update is called once per frame

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        scoreValue = 0;
    }

    public void AddScore()
    {
        scoreValue += 1;
        audioSource.PlayOneShot(scoreSound);
    }
}
