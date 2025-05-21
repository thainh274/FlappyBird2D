using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private Renderer backgroundRenderer;

    private void Start()
    {
        backgroundRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver) return;
        backgroundRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
