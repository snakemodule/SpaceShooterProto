using System;
using UnityEngine;

/// <summary>
/// Performs ship/player functions depending on input.
/// </summary>
public class ShipController : MonoBehaviour
{
    private Rigidbody _body;
    private TorpedoLauncher _torpedoLauncher;

    //set by `PlayerInput`
    [NonSerialized] public float TurningInput;
    [NonSerialized] public bool ThrusterInput;
    [NonSerialized] public bool Fire1Input;

    //set in inspector
    public float turningSpeed = 300f;

    private void Awake()
    {
        _body = GetComponent<Rigidbody>();
        _torpedoLauncher = GetComponent<TorpedoLauncher>();
    }

    private void Update()
    {
        if (Fire1Input)
            _torpedoLauncher.launch(_body.velocity);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (ThrusterInput)
            _body.AddForce(transform.forward * 15f);
        if (TurningInput != 0)
            transform.Rotate(0, turningSpeed * TurningInput * Time.deltaTime, 0);
    }

}