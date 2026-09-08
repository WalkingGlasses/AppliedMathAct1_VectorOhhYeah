using UnityEngine;
using UnityEngine.SceneManagement;

public class NoGoZone : MonoBehaviour
{
    public Transform player;

    [Header("Detection Distances")]
    public float warningDistance = 2f;
    public float dangerDistance = 1f;

    [Header("Danger Timer")]
    public float maxDangerTime = 3f;

    [Header("Shake")]
    public float shakeAmount = 0.1f;
    public float shakeSpeed = 20f;

    private float dangerTimer = 0f;
    private Vector3 originalPosition;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        originalPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player == null)
            return;

        // Calculating wiggle distance
        float distance = Vector3.Distance(
            player.position,
            transform.position
        );

        // Warning state
        if (distance <= warningDistance)
        {
            spriteRenderer.color = Color.red;

            // Shakira
            float shakeX = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;
            float shakeY = Mathf.Cos(Time.time * shakeSpeed) * shakeAmount;

            transform.position = originalPosition +
                                 new Vector3(shakeX, shakeY, 0f);
        }
        else
        {
            spriteRenderer.color = Color.yellow;
            transform.position = originalPosition;
        }

        // https://www.youtube.com/watch?v=UNSK2tfhefg
        if (distance <= dangerDistance)
        {
            dangerTimer += Time.deltaTime;

            if (dangerTimer >= maxDangerTime)
            {
                RestartScene();
            }
        }
        else
        {
            dangerTimer = 0f;
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}