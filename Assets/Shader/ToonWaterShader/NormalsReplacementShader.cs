using UnityEngine;
using UnityEngine.Rendering.Universal;

public class NormalsReplacementShader : MonoBehaviour
{
    [SerializeField]
    Shader normalsShader;

    private RenderTexture renderTexture;
    public Camera normalCamera;

    private void Start()
    {
        Camera thisCamera = GetComponent<Camera>();

        // Create a render texture matching the main camera's current dimensions.
        renderTexture = new RenderTexture(thisCamera.pixelWidth, thisCamera.pixelHeight, 24);
        // Surface the render texture as a global variable, available to all shaders.
        Shader.SetGlobalTexture("_CameraNormalsTexture", renderTexture);

        // Setup a copy of the camera to render the scene using the normals shader.
        // GameObject copy = new GameObject("Normals camera");
        // normalCamera = copy.AddComponent<Camera>();
        normalCamera.CopyFrom(thisCamera);
        normalCamera.transform.SetParent(transform);
        normalCamera.targetTexture = renderTexture;
        normalCamera.SetReplacementShader(normalsShader, "RenderType");
        normalCamera.depth = thisCamera.depth - 1;

        normalCamera.GetComponent<UniversalAdditionalCameraData>().SetRenderer(1);
    }
}
