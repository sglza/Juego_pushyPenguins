using UnityEngine;

public class obstacleMovement : MonoBehaviour
{
    public GameObject[] waypoints;
    int current = 0;
    float wPradius = 1;
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!FindObjectOfType<GameManager>().gameover)
        {
            if (Vector3.Distance(waypoints[current].transform.position, transform.position) < wPradius)
            {
                current++;
            }
            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        }

    }

}
