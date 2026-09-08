using UnityEngine;

public class FinishZone : MonoBehaviour
{
    public Transform player;
    public float finishDistance = 1.5f;

    public GameObject winPanel;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (winPanel != null)
            winPanel.SetActive(false);
    }

    void Update()
    {
        if (player == null)
            return;

        float distance = Vector3.Distance(
            player.position,
            transform.position
        );

        if (distance <= finishDistance)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
    }
}