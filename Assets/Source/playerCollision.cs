using UnityEngine;

public class playerCollision : MonoBehaviour
{
    public Rigidbody rb;
    public playerMovement playerMovement;
    //public Transform transform;

    private void OnCollisionEnter(Collision col)
    {
        switch (col.collider.tag)
        {
            case "Item":
                handleItem(col);
                break;
            case "o":
                //Debug.Log("Started Collision");
                rb.useGravity = true;
                gameObject.GetComponent<playerMovement>().enabled = false;
                break;
            case "cliff":
                handleDeath();
                break;
            case "death":
                handleDeath();
                break;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        switch (col.collider.tag)
        {
            case "o":
                //Debug.Log("Stopped Collision");
                gameObject.GetComponent<playerMovement>().enabled = true;
                break;
        }
    }

    private void handleItem(Collision col)
    {
        col.gameObject.SetActive(false);
    }

    private void handleCliff()
    {
        rb.AddForce(0, -800, 0);
    }

    private void handleDeath()
    {
        FindObjectOfType<GameManager>().GameOver();
        gameObject.GetComponent<playerMovement>().enabled = false;
    }

}
