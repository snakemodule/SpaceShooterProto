using UnityEngine;

/// <summary>
/// Orbiting space junk. Splits when non-trigger 
/// (ie. not other spacejunk) enters this trigger.
/// Destroys itself and other collider object in the process.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class BigJunk : JunkCommon
{
    //set by inspector
    #region
    public GameObject MediumJunkPrefab;
    #endregion

    private void Start()
    {
        var vDir1 = UnityEngine.Random.insideUnitCircle * 30f;
        body.velocity = new Vector3(vDir1.x, 0f, vDir1.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            GameObject.Destroy(other.gameObject);
            GameObject.Destroy(gameObject);

            JunkCommon.splitJunk<MediumJunk>(MediumJunkPrefab, transform,
                this.body, this.OrbitalAnchor, "MediumJunkAnchor");
        }

    }

}
