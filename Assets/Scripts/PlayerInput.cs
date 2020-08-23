using UnityEngine;

/// <summary>
/// Forwards player input to `ShipController` on this gameobject
/// </summary>
public class PlayerInput : MonoBehaviour
{

    private ShipController _shipController;
    private const string _horizontalID = "Horizontal";
    private const string _thrusterID = "Thruster";
    private const string _fire1ID = "FireTorpedo";

    private void Awake()
    {
        _shipController = GetComponent<ShipController>();
    }

    private void Update()
    {
        _shipController.TurningInput = Input.GetAxis(_horizontalID);
        _shipController.ThrusterInput = Input.GetButton(_thrusterID);
        _shipController.Fire1Input = Input.GetButtonDown(_fire1ID);
    }
}