using System;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Orbiting space junk. Splits when non-trigger 
/// (ie. not other spacejunk) enters this trigger.
/// Destroys itself and other collider object in the process.
/// </summary>
public class MediumJunk : JunkCommon
{
    //set by inspector
    #region
    public GameObject SmallJunkPrefab;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            GameObject.Destroy(other.gameObject);
            GameObject.Destroy(gameObject);

            JunkCommon.splitJunk<SmallJunk>(SmallJunkPrefab, transform,
                this.body, this.OrbitalAnchor, "SmallJunkAnchor");
        }

    }

}
