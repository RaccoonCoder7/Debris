using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMgr_Game : MonoBehaviour
{
    public RawImage image;

    private void Awake()
    {
        image.gameObject.SetActive(true);
    }

    public IEnumerator FadeIn()
    {
        image.gameObject.SetActive(true);
        Color color = image.color;
        float i = 0;

        while (true)
        {

            yield return new WaitForSeconds(0.002f);

            i += Time.deltaTime;
            color.a = i;
            image.color = color;

            if (i >= 1.0f)
            {
                break;
            }
        }

        SceneManager.LoadScene("MoveScene");
    }

    public IEnumerator FadeOut()
    {
        image.gameObject.SetActive(true);
        Color color = image.color;
        float i = 1;

        while (true)
        {
            yield return new WaitForSeconds(0.002f);

            i -= Time.deltaTime;
            color.a = i;
            image.color = color;

            if (i <= 0.0f)
            {
                break;
            }
        }

        image.gameObject.SetActive(false);
    }
}
