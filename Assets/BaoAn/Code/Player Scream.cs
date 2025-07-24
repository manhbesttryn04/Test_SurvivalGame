using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FallScreamCharacterController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip screamClip;
    public float fallHeightThreshold = 3f;

    private CharacterController controller;
    private float fallStartY;
    private bool isFalling = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // N?u nh�n v?t ?ang r?i (kh�ng ch?m ??t v� t?c ?? Y �m)
        if (!controller.isGrounded && !isFalling && controller.velocity.y < -0.1f)
        {
            isFalling = true;
            fallStartY = transform.position.y;
        }

        // N?u v?a ch?m ??t sau khi r?i
        if (controller.isGrounded && isFalling)
        {
            float fallDistance = fallStartY - transform.position.y;

            if (fallDistance >= fallHeightThreshold)
            {
                audioSource.PlayOneShot(screamClip);
                // Debug.Log("La l�n v� r?i t? cao " + fallDistance + "m");
            }

            isFalling = false;
        }
    }
}
