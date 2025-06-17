using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // The Prefab we will spawn
    public GameObject mathWallPrefab;
    
    // The materials we will apply
    public Material positiveMaterial;
    public Material negativeMaterial;

    // --- Tunable Settings ---
    public float spawnInterval = 10f;
    public float scrollSpeed = 10f;

    // --- Private Variables ---
    private float spawnZ = 200f; // Where the walls will appear

    void Start()
    {
        // Call the SpawnPairOfWalls function every 'spawnInterval' seconds, starting after 5 seconds.
        InvokeRepeating(nameof(SpawnPairOfWalls), 5f, spawnInterval);
    }

    void SpawnPairOfWalls()
    {
        // Spawn the parent MathWall object at the far end of the platform
        Vector3 spawnPosition = new Vector3(0, 0, spawnZ);
        GameObject newWallObject = Instantiate(mathWallPrefab, spawnPosition, Quaternion.identity);

        // Set its overall scroll speed
        newWallObject.GetComponent<ObstacleScroller>().scrollSpeed = this.scrollSpeed;
        
        WallController[] wallControllers = newWallObject.GetComponentsInChildren<WallController>();
        WallController leftWall = wallControllers[0];
        WallController rightWall = wallControllers[1];

        // Assign the materials to both controllers so they know what colors to use
        leftWall.positiveMaterial = this.positiveMaterial;
        leftWall.negativeMaterial = this.negativeMaterial;
        rightWall.positiveMaterial = this.positiveMaterial;
        rightWall.negativeMaterial = this.negativeMaterial;

        // Tell each wall to set itself up, each with its own random chance of being positive
        leftWall.SetupWall(Random.value > 0.5f); 
        rightWall.SetupWall(Random.value > 0.5f);

    }
}