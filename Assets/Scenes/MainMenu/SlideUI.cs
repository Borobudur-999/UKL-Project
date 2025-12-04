using UnityEngine;
using System.Collections;

public class SlidePanelController : MonoBehaviour
{
    public RectTransform panel;
    public float animDuration = 0.35f;

    private float offX;
    private float onX;
    private Coroutine animRoutine;

    void Start()
    {
        onX = panel.anchoredPosition.x;

        // hitung jarak keluar berdasarkan lebar panel + layar
        offX = onX + panel.rect.width + 200f;  

        // Set panel ke kanan
        panel.anchoredPosition = new Vector2(offX, panel.anchoredPosition.y);
    }

    public void OpenPanel()
    {
        StartSlide(offX, onX);
    }

    public void ClosePanel()
    {
        StartSlide(panel.anchoredPosition.x, offX);
    }

    private void StartSlide(float fromX, float toX)
    {
        if (animRoutine != null) StopCoroutine(animRoutine);
        animRoutine = StartCoroutine(SlideAnim(fromX, toX));
    }

    IEnumerator SlideAnim(float fromX, float toX)
    {
        float t = 0;

        while (t < animDuration)
        {
            t += Time.deltaTime;
            float p = Mathf.SmoothStep(0, 1, t / animDuration);
            float x = Mathf.Lerp(fromX, toX, p);
            panel.anchoredPosition = new Vector2(x, panel.anchoredPosition.y);
            yield return null;
        }

        panel.anchoredPosition = new Vector2(toX, panel.anchoredPosition.y);
    }
}
