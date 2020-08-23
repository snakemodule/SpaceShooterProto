using UnityEngine;

/// <summary>
/// Instantiates JunkPrefabs at random locations in orbit around GravityAnchor on Awake
/// </summary>
public class JunkSpawner : MonoBehaviour
{
    //set by inspector
    #region
    public GameObject GravityAnchor;
    public GameObject BigJunkPrefab;
    #endregion

    private void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            //TODO declare a constant for default orbital distance somewhere else
            Vector3 randomSpawn = GravityAnchor.transform.position + (Random.onUnitSphere * 80f); 
            GameObject spawnedJunk = Instantiate(BigJunkPrefab, randomSpawn, Quaternion.identity);
            
            var junkScript = spawnedJunk.GetComponent<BigJunk>();
            junkScript.OrbitalAnchor =
                Orbit.attachOrbitalAnchor(junkScript.body, GravityAnchor.transform, "JunkAnchor");
        }
    }
        
}
