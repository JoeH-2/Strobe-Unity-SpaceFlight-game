using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public bool follow = true;

    // Update is called once per frame
    void Update()
    {
        if (follow == true)
        {
            transform.position = player.position + offset;
        }
    }
}
