using UnityEngine;

/// <summary>
/// Orbiting space junk. When non-trigger (ie. not other spacejunk) enters
/// this trigger; destroys itself and other collider object.
/// </summary>
public class SmallJunk : JunkCommon
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            GameObject.Destroy(other.gameObject);
            GameObject.Destroy(gameObject);            
        }
    }
}
