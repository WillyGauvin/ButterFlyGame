using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Movement : MonoBehaviour
{
    [SerializeField] private TMP_Text pitchText;
    [SerializeField] private TMP_Text screenHeightText;
    private void OnEnable()
    {
        Controller.OnFlap += OnFlap;
        Controller.OnLayEgg += OnLayEgg;
        Controller.OnPitchChange += OnPitchChange;
    }

    private void OnDisable()
    {
        Controller.OnFlap -= OnFlap;
        Controller.OnLayEgg -= OnLayEgg;
        Controller.OnPitchChange -= OnPitchChange;
    }

    private void OnFlap()
    {
        Debug.Log("Flap");
    }

    private void OnLayEgg()
    {
        Debug.Log("Lay Egg");
    }

    private void OnPitchChange(Vector2 mousePos)
    {
        float mouseY = Mathf.Clamp(mousePos.y, 0, Screen.height);
        float screenHeight = Screen.height;
        //Remap the mouse position to range: -1 to 1
        float pitch = -1.0f + ((mouseY * 2.0f) / screenHeight);

        pitchText.text = "X:" + mousePos.x + "\nY:" + mousePos.y;
        screenHeightText.text = "Screen Height: " + screenHeight;

        Debug.Log(pitch);

    }
}
