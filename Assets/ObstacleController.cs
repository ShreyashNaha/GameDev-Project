using UnityEngine;

public class ObstacleScroller : MonoBehaviour
{
    // We will set this from our Spawner later
    public float scrollSpeed = 10f;

    void Update()
    {
        // Move this object (and all its children) towards the player
        transform.Translate(Vector3.back * scrollSpeed * Time.deltaTime);

        // Destroy this object if it goes too far past the player's starting area
        if (transform.position.z < -210)
        {
            Destroy(gameObject);
        }
    }
}