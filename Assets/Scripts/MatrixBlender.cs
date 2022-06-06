using UnityEngine;
using System.Collections;

/// <summary>
/// Blends from orthographic cam to perspective camera.
/// Also moves the camera transform to target position.
/// </summary>

[RequireComponent(typeof(Camera))]
public class MatrixBlender : MonoBehaviour
{
    public static Matrix4x4 MatrixLerp(Matrix4x4 from, Matrix4x4 to, float time)
    {
        Matrix4x4 ret = new Matrix4x4();
        for (int i = 0; i < 16; i++)
            ret[i] = Mathf.Lerp(from[i], to[i], time);
        return ret;
    }

    private IEnumerator LerpFromTo(Matrix4x4 src, Matrix4x4 dest, Vector3 targetPosition, float duration)
    {
        float totalTime = 0f;
        while (totalTime < duration)
        {
            totalTime += Time.deltaTime;

            Camera.main.projectionMatrix = MatrixLerp(src, dest, totalTime / duration); //Blend camera from ortho to perspective
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPosition, totalTime / duration);   //Move camera position
            yield return new WaitForEndOfFrame();
        }
        Camera.main.projectionMatrix = dest;
        Camera.main.transform.position = targetPosition;
    }

    public Coroutine BlendToMatrix(Matrix4x4 targetMatrix, Vector3 targetPosition,float duration)
    {
        return StartCoroutine(LerpFromTo(Camera.main.projectionMatrix, targetMatrix, targetPosition, duration));
    }
}

