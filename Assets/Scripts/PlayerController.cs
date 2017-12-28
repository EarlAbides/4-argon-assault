using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    #region Designer Variables

    [Header("General")]
    [Tooltip("In ms^-1")]
    [SerializeField]
    float controlSpeed = 18.0f;

    [Tooltip("In meters")]
    [SerializeField]
    float xRange = 5.0f;

    [Tooltip("In meters")]
    [SerializeField]
    float yRange = 4.0f;

    [Header("Screen Position Based")]
    [SerializeField]
    float positionPitchFactor = -5.0f;

    [SerializeField]
    float positionYawFactor = 5.0f;

    [Header("Control Position Based")]
    [SerializeField]
    float controlPitchFactor = -20.0f;

    [SerializeField]
    float controlRollFactor = -20.0f;

    #endregion

    #region Member Variables

    private float xThrow;
    private float yThrow;
    private bool playerDying;

    #endregion

    #region Unity Hooks

    // Update is called once per frame
    void Update()
    {
        if (!playerDying)
        {
            CaptureInput();
            ProcessTranslation();
            ProcessRotation();
        }
    }

    #endregion

    #region Player Hooks

    void OnPlayerDeath()
    {
        playerDying = true;
    }

    #endregion

    #region Private Methods

    private void CaptureInput()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
    }

    private void ProcessTranslation()
    {
        // Calculate X-Axis movement
        float xOffsetThisFrame = Time.deltaTime * xThrow * controlSpeed;
        float newXPos = Mathf.Clamp(transform.localPosition.x + xOffsetThisFrame, -xRange, xRange);

        // Calculate Y-Axis movement
        float yOffsetThisFrame = Time.deltaTime * yThrow * controlSpeed;
        float newYPos = Mathf.Clamp(transform.localPosition.y + yOffsetThisFrame, -yRange, yRange);

        // Set new local position
        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        // Process pitch
        float pitchFromPosition = transform.localPosition.y * positionPitchFactor;
        float pitchFromThrow = yThrow * controlPitchFactor;
        float pitch = pitchFromPosition + pitchFromThrow;

        // Process yaw
        float yaw = transform.localPosition.x * positionYawFactor;

        // Process roll
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    #endregion
}
