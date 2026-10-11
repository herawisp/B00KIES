using UnityEngine;

public class EnvironmentUI : MonoBehaviour {
    
    //==============================================================================================//
    //==============================================================================================//

    public Shaker WindowFrame;
    public Shaker PineTrees;
    public Shaker Clouds;

    //==============================================================================================//
    //==============================================================================================//
    
    public void Shake() {
        float shakeDuration = GameSettings.Instance.ShakeDuration;
        float shakeMagnitude = GameSettings.Instance.ShakeMagnitude;

        WindowFrame.Shake(shakeDuration, shakeMagnitude);
        PineTrees.Shake(shakeDuration, shakeMagnitude);
        Clouds.Shake(shakeDuration, shakeMagnitude);
    }

    //==============================================================================================//
    //==============================================================================================//
}
