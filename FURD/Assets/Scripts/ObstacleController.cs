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
        rBody = GetComponent<Rigidbody>();
        float rand = Random.Range(0f,1f);
        if(rand > 0.5f)
        {
            transform.localScale = new Vector3(1, Random.Range(1, 5), 0.5f);
        }
        else
        {
            transform.localScale = new Vector3(Random.Range(1, 5),1, 0.5f);
        }
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        vel = speed * Mathf.Log10(5 + 2*score.scoreValue);


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
        rBody.MovePosition(transform.position + Vector3.back * Time.deltaTime * vel);
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
