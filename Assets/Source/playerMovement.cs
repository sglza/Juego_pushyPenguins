using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Transform move;
    public void FixedUpdate()
    {
        if (move.localPosition.x < 0)
        {
            Vector3 localPos = move.localPosition;
            localPos.x = localPos.x += 0.01f;
            transform.localPosition = localPos;
        }
    }

}