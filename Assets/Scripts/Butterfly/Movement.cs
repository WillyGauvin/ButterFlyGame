using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private TMP_Text mousePosText;
    [SerializeField] private TMP_Text screenHeightText;
    [SerializeField] private TMP_Text pitchText;
    [SerializeField] private TMP_Text pressedButtonText;

    private int pressedFly = 0;
    private int pressedEgg = 0;
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
        pressedFly += 1;
        pressedButtonText.text = "Egg: " + pressedEgg + "\nFly: " + pressedFly;
        Debug.Log("Flap");
    }

    private void OnLayEgg()
    {
        pressedEgg += 1;
        pressedButtonText.text = "Egg: " + pressedEgg + "\nFly: " + pressedFly;
        Debug.Log("Lay Egg");
    }

    private void OnPitchChange(Vector2 mousePos)
    {
        float mouseY = Mathf.Clamp(mousePos.y, 0, Screen.height);
        float screenHeight = Screen.height;
        //Remap the mouse position to range: -1 to 1
        float pitch = -1.0f + ((mouseY * 2.0f) / screenHeight);

        mousePosText.text = "X:" + mousePos.x + "\nY:" + mousePos.y;
        screenHeightText.text = "Screen Height: " + screenHeight;
        pitchText.text = "Pitch: " + pitch;
        Debug.Log(pitch);

    }
}
