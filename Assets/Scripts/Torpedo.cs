using System;
using UnityEngine;


/// <summary>
/// Torpedo anchored into orbit. 
/// On collision, destroys itself and other object.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Torpedo : MonoBehaviour
{
    //set by other script
    #region
    [NonSerialized] public ConfigurableJoint TorpedoAnchor;
    #endregion

    //set in awake
    #region
    [NonSerialized] public Rigidbody Body;
    #endregion

    private void Awake()
    {
        Body = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Destroy(collision.gameObject);
        GameObject.Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        UnityEngine.Object.Destroy(TorpedoAnchor);
    }




}
