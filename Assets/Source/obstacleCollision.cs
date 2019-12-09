using UnityEngine;

public class obstacleCollision : MonoBehaviour
{

    public Transform move;
    public obstacleMovement movement;
    private float originZ;

    void OnCollisionEnter(Collision col)
    {
        switch (col.collider.tag)
        {
            case "floor":
                floorHandler();
                break;
            case "death":
                originZ = move.localPosition.z;
                deathHandler(originZ);
                break;
            case "cliff":
                cliffHandler();
                break;
        }

    }

    private void floorHandler()
    {
        movement.enabled = true;
    }

    private void deathHandler(float z)
    {
        Vector3 newPos = new Vector3(11.26f, 2.1f, z);
        move.localPosition = newPos;
        movement.speed = Random.Range(5f, 25f);
    }

    private void cliffHandler()
    {
        movement.enabled = false;
    }

}
