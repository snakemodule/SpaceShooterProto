using UnityEngine;

/// <summary>
/// Enables gameobject to launch torpedo prefab
/// </summary>
public class TorpedoLauncher : MonoBehaviour
{

    //set in inspector
    #region
    public GameObject TorpedoPrefab;
    public GameObject GravityAnchor;
    #endregion

    /// <summary>
    /// Instantiates `TorpedoPrefab` in front of this gameobject, putting it in orbit.
    /// Launches torpedo with forward velocity and adds `shipVelocity` as well.
    /// </summary>
    /// <param name="shipVelocity">
    /// The velocity component that is inherited from the ship's movement
    /// </param>
    public void launch(Vector3 shipVelocity)
    {
        GameObject launchedTorpedo = Instantiate(TorpedoPrefab,
            transform.position + (transform.forward * 1.2f),
            transform.rotation * Quaternion.Euler(90,0,0));

        Torpedo torpedoScript = launchedTorpedo.GetComponent<Torpedo>();

        torpedoScript.TorpedoAnchor = 
            Orbit.attachOrbitalAnchor(torpedoScript.Body, GravityAnchor.transform, "TorpedoAnchor");              

        //give velocity to torpedo
        torpedoScript.Body.velocity = shipVelocity + (launchedTorpedo.transform.forward*1500f);

    }

}
