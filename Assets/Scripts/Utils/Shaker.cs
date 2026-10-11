using System.Collections;
using UnityEngine;

public class Shaker : MonoBehaviour {
    
    //==============================================================================================//
    //==============================================================================================//

    private Coroutine ShakeRoutine;
    private Vector3 OriginalLocalPos;

    //==============================================================================================//
    //==============================================================================================//

    public void Shake(float duration, float magnitude) {
        if (ShakeRoutine != null) {
            StopCoroutine(ShakeRoutine);
            transform.localPosition = OriginalLocalPos;
        }
        OriginalLocalPos = transform.localPosition;
        ShakeRoutine = StartCoroutine(ShakeCoroutine(duration, magnitude));
    }

    //==============================================================================================//
    //==============================================================================================//

    private IEnumerator ShakeCoroutine(float duration, float magnitude) {
        float elapsed = 0f;

        while (elapsed < duration) {
            float damper = 1f - (elapsed / duration);
            Vector2 offset = Random.insideUnitCircle * magnitude * damper;

            transform.localPosition = OriginalLocalPos + (Vector3)offset;

            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        transform.localPosition = OriginalLocalPos;
        ShakeRoutine = null;
    }

    //==============================================================================================//
    //==============================================================================================//
}