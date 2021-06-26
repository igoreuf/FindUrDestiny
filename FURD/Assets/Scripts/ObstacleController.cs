using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleController : MonoBehaviour
{
    public float speed = 5f;
    //public float jumpForce = 250f;
    private Rigidbody rBody;
    private Score score;
    private float vel;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("GameController").GetComponent<Score>(); ;
        rBody = GetComponent<Rigidbody>();
        vel = speed * GamePlayAI.SpeedSpawn();


    }
    private void Update()
    {
        if (GameManager.isGameOver)
        {
            vel = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rBody.MovePosition(transform.position + Time.deltaTime * vel * Vector3.back);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            score.AddScore();
            Destroy(gameObject);
        }
    }
}
