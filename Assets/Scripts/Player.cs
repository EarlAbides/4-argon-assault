using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    #region Designer Variables

    [Tooltip("In ms^-1")]
    [SerializeField]
    float speed = 18.0f;

    [Tooltip("In meters")]
    [SerializeField]
    float xRange = 5.0f;

    [Tooltip("In meters")]
    [SerializeField]
    float yRange = 4.0f;

    [SerializeField]
    float positionPitchFactor = -5.0f;

    [SerializeField]
    float controlPitchFactor = -20.0f;

    [SerializeField]
    float positionYawFactor = 5.0f;

    [SerializeField]
    float controlRollFactor = -20.0f;

    #endregion

    #region Member Variables

    private float xThrow;
    private float yThrow;

    #endregion

    #region Unity Hooks

    // Update is called once per frame
    void Update()
    {
        CaptureInput();
        ProcessTranslation();
        ProcessRotation();
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                print("Collided with enemy");
                break;
            default:
                print("Player collided with something!");
                break;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Enemy":
                print("Player triggered an enemy");
                break;
            default:
                print("Player triggered something");
                break;
        }
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
        float xOffsetThisFrame = Time.deltaTime * xThrow * speed;
        float newXPos = Mathf.Clamp(transform.localPosition.x + xOffsetThisFrame, -xRange, xRange);

        // Calculate Y-Axis movement
        float yOffsetThisFrame = Time.deltaTime * yThrow * speed;
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
