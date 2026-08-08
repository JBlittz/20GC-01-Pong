using UnityEngine;
using UnityEngine.UI;

public class PontuationManager : MonoBehaviour
{
    [SerializeField]
    private Ball ball;
    [SerializeField]
    private Text points1Text;
    [SerializeField]
    private Text points2Text;
    private int[] points = {0, 0};
    void Start()
    {
        ball.OffScreen += OnBallOffScreen;
    }

    void OnBallOffScreen(float position)
    {
        int i = position <= 0f ? 1 : 0;
        points[i]++;
        points1Text.text = points[0].ToString();
        points2Text.text = points[1].ToString();
    }
}
