using System;
using UnityEngine;

/// <summary>
/// Common parts for all sizes of spacejunk. 
/// Spacejunk is anchored in orbit using a 
/// gameobject with `ConfigurableJoint` at the center.
/// 
/// </summary>
public class JunkCommon : MonoBehaviour
{    
    //set by other script
    #region
    [NonSerialized] public ConfigurableJoint OrbitalAnchor;
    #endregion

    //set in awake
    #region
    [NonSerialized] public Rigidbody body;
    #endregion

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Splits an orbiting junk object into two new ones.
    /// </summary>
    /// <typeparam name="PrefabMainScript">The space junk script that is expected to be on the prefab</typeparam>
    /// <param name="prefab">The prefab that will be instantiated to replace the original</param>
    /// <param name="originalJunk">The junk that will be deleted</param>
    /// <param name="originalRB">Rigidbody of original</param>
    /// <param name="originalJunkAnchor">Joint that anchors original junk object in orbit</param>
    /// <param name="anchorName">New object name to differentiate anchors created this way</param>
    public static void splitJunk<PrefabMainScript>(GameObject prefab, Transform originalJunk,
        Rigidbody originalRB, ConfigurableJoint originalJunkAnchor,
        string anchorName = "OrbitalAnchor")
        where PrefabMainScript : JunkCommon
    {
        var originalPosition = originalJunk.position;

        GameObject splitJunk1 = GameObject.Instantiate(prefab);
        splitJunk1.transform.position = originalPosition;
        PrefabMainScript junkScript1 = splitJunk1.GetComponent<PrefabMainScript>();

        //take over the original's anchor
        junkScript1.OrbitalAnchor = originalJunkAnchor;
        originalJunkAnchor.gameObject.name = anchorName;
        junkScript1.OrbitalAnchor.connectedBody = junkScript1.body;


        GameObject splitJunk2 = GameObject.Instantiate(prefab);
        splitJunk2.transform.position = originalPosition;
        PrefabMainScript junkScript2 = splitJunk2.GetComponent<PrefabMainScript>();
        //create anchor under same parent
        junkScript2.OrbitalAnchor = Orbit.attachOrbitalAnchor(junkScript2.body,
            originalJunkAnchor.transform.parent, "MediumJunkAnchor");

        float vOriginal = originalRB.velocity.magnitude;
        float v1 = UnityEngine.Random.value;
        float v2 = 1f - v1;
        v1 *= vOriginal;
        v2 *= vOriginal;

        Vector2 vDir1 = UnityEngine.Random.insideUnitCircle.normalized * v1;
        Vector2 vDir2 = UnityEngine.Random.insideUnitCircle.normalized * v2;

        junkScript1.body.velocity = new Vector3(vDir1.x, 0f, vDir1.y);
        junkScript2.body.velocity = new Vector3(vDir2.x, 0f, vDir2.y);
    }

}
