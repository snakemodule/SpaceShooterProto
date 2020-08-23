using UnityEngine;

/// <summary>
/// Updates the position of the gameobject so that it follows another gameobject
/// around with a fixed position and rotation offset.
/// Disables itself if the followed object is destroyed, or otherwise becomes null.
/// </summary>
public class CameraFixedFollow : MonoBehaviour
{

    //set in inspector
    #region
    public GameObject followedObject;
    public Vector3 cameraPositionOffset;
    public Vector3 cameraRotationOffset;
    #endregion

    private void Update()
    {
        if (followedObject == null)
        {
            enabled = false;
        }
        else
        {
            var followedTransform = followedObject.transform;
            var followedRotation = followedTransform.rotation;

            Vector3 rotatedCamPosOffset = Matrix4x4.Rotate(followedRotation) * cameraPositionOffset;
            transform.position = followedTransform.position + rotatedCamPosOffset;
            transform.rotation = followedRotation * Quaternion.Euler(cameraRotationOffset);
        }
    }
}
