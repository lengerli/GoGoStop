using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MatrixBlender))]
public class PerspectiveSwitcher : MonoBehaviour
{
    public Camera orthoCamPrefab;
    public Camera perspCamPrefab;
    public float blendDuration;

    private Matrix4x4 ortho,
                        perspective;

    private MatrixBlender blender;
    [SerializeField]
    bool orthoOn;
    
    void Start()
    {
        ortho = orthoCamPrefab.projectionMatrix;
        perspective = perspCamPrefab.projectionMatrix;
        
        orthoOn = true;
        blender = (MatrixBlender)GetComponent(typeof(MatrixBlender));
    }

    public void ZoomCamForNinjaAttack()
    {
        blender.BlendToMatrix(perspective, orthoCamPrefab.gameObject.transform.position, blendDuration);
    }


    public void TestZoom()
    {
            orthoOn = !orthoOn;
            if (orthoOn)
                blender.BlendToMatrix(ortho, orthoCamPrefab.gameObject.transform.position, blendDuration);
            else
                blender.BlendToMatrix(perspective, perspCamPrefab.gameObject.transform.position, blendDuration);

    }
}
