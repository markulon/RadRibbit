using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Player's transform
    public GameObject boundaryMin; // GameObject representing minimum boundary
    public GameObject boundaryMax; // GameObject representing maximum boundary

    void Update()
    {
        // Use the positions of the boundary GameObjects to define min and max values
        float minX = boundaryMin.transform.position.x;
        float minY = boundaryMin.transform.position.y;
        float maxX = boundaryMax.transform.position.x;
        float maxY = boundaryMax.transform.position.y;

        // Clamp both X and Y positions within the boundaries
        float x = Mathf.Clamp(player.position.x, minX, maxX);
        float y = Mathf.Clamp(player.position.y, minY, maxY);

        // Set camera position
        transform.position = new Vector3(x, y, transform.position.z);
    }
}

