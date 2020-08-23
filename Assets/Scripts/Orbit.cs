using System;
using UnityEngine;

class Orbit
{
    /// <summary>
    /// Creates new GameObject as a child of `anchorPoint` to serve as an anchor 
    /// for `orbitalObject` by means of a `ConfigurableJoint` component.
    /// The anchor's world position will be the same as `anchorPoint`
    /// </summary>
    /// <param name="orbitalObject">Object to attach to new anchor</param>
    /// <param name="anchorPoint">Parent and position of new anchor</param>
    /// <param name="name">Name of the new anchor object</param>
    /// <returns>
    /// `ConfigurableJoint` component of the new anchor, connected to `orbitalObject`
    ///  </returns>    
    public static ConfigurableJoint attachOrbitalAnchor(Rigidbody orbitalObject, 
        Transform anchorPoint, string name = "OrbitalAnchor")
    {
        //create anchor at anchorpoint
        
        var orbitalAnchor = 
            new GameObject(name, new Type[] { typeof(Rigidbody) } );
        orbitalAnchor.transform.SetParent(anchorPoint);
        orbitalAnchor.transform.localPosition = Vector3.zero;

        //give anchor rigidbody
        var anchorBody = orbitalAnchor.GetComponent<Rigidbody>();
        anchorBody.useGravity = false;
        anchorBody.isKinematic = true;

        //give anchor joint and attach orbitalObject
        var joint = orbitalAnchor.AddComponent<ConfigurableJoint>();
        joint.xMotion = ConfigurableJointMotion.Locked;
        joint.yMotion = ConfigurableJointMotion.Locked;
        joint.zMotion = ConfigurableJointMotion.Locked;
        joint.connectedBody = orbitalObject;

        return joint;
    }

}

