using UnityEngine;
using System.Collections;

namespace UI.Screens
{
    public class UIScaling : MonoBehaviour
    {
        bool isScaling = false;

        public IEnumerator scaleOverTime(Transform objectToScale, Vector3 toScale, float duration)
        {
            //Make sure there is only one instance of this function running
            if (isScaling)
            {
                yield break; ///exit if this is still running
            }
            isScaling = true;

            float counter = 0;

            //Get the current scale of the object to be moved
            Vector3 startScaleSize = objectToScale.localScale;

            while (counter < duration)
            {
                counter += Time.deltaTime;
                objectToScale.localScale = Vector3.Lerp(startScaleSize, toScale, counter / duration);
                yield return null;
            }

            isScaling = false;
        }
    }
}