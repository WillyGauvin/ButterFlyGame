using UnityEngine;
using UnityEngine.InputSystem;
using System;

[DefaultExecutionOrder(-100)]
public class Controller : MonoBehaviour
{
    public static Controller Instance { get; private set; }

    private PlayerControls m_controller;

    public static event Action OnFlap;
    public static event Action OnLayEgg;
    public static event Action<Vector2> OnPitchChange;

    private Action<InputAction.CallbackContext> flapCallback;
    private Action<InputAction.CallbackContext> layEggCallback;
    private Action<InputAction.CallbackContext> pitchCallback;

    private void Awake()
    {
        Instance = this;

        m_controller = new PlayerControls();
        m_controller.Player.Enable();

        flapCallback = ctx => Flap();
        layEggCallback = ctx => LayEgg();
        pitchCallback = ctx => PitchChange(ctx.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        m_controller.Player.Flap.performed += flapCallback;
        m_controller.Player.LayEgg.performed += layEggCallback;
        m_controller.Player.Pitch.performed += pitchCallback;
    }

    private void OnDisable()
    {
        m_controller.Player.Flap.performed -= flapCallback;
        m_controller.Player.LayEgg.performed -= layEggCallback;
        m_controller.Player.Pitch.performed -= pitchCallback;
    }

    private void Flap() => OnFlap?.Invoke();
    private void LayEgg() => OnLayEgg?.Invoke();
    private void PitchChange(Vector2 mousePos) => OnPitchChange?.Invoke(mousePos);
}
