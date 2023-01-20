using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptionsHandling : MonoBehaviour
{
    public string[] captionName;
    public string[] captionContent;
    public int[] captionTime;

    public Text captionNameText;
    public Text captionContentText;


    private Text[] captionsTexts;
    private Color originalColor;
    private int currentCaption = 0;
    private int endingCaptionNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        captionsTexts = new Text[] { captionNameText, captionContentText };
        originalColor = new Color(captionsTexts[0].color.r, captionsTexts[0].color.g, captionsTexts[0].color.b, 0f);
        GetComponent<Image>().color = new Color(0, 0, 0, 0f);

        foreach (Text text in captionsTexts)
        {
            text.color = originalColor;
        }

        NextCaption(true, 0, 999);
    }

    public void NextCaption(bool firstCaption, int startingCaption, int endingCaption)
    {

        endingCaptionNumber = endingCaption;

        if(startingCaption != 999) currentCaption = startingCaption;

        if(!firstCaption) currentCaption++;

        if (currentCaption < captionName.Length || currentCaption < endingCaption)
        {
            GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
            captionNameText.text = captionName[currentCaption];
            captionContentText.text = captionContent[currentCaption];
            StartCoroutine(TriggerFirstCaption(1f));
        } else {
            GetComponent<Image>().color = new Color(0, 0, 0, 0f);
        }
    }

    IEnumerator TriggerFirstCaption(float duration)
    {
        float t = 0f;
        
        while (t <= duration)
        {
            t += Time.deltaTime;
            foreach (Text text in captionsTexts)
            {
                text.color = Color.Lerp(originalColor, Color.white, t / duration);
            }
            yield return null;
        }

        yield return new WaitForSeconds(captionTime[currentCaption]);

        t = 0f;
        while (t <= duration)
        {
            t += Time.deltaTime;
            foreach (Text text in captionsTexts)
            {
                text.color = Color.Lerp(Color.white, originalColor, t / duration);
            }
            yield return null;
        }

        NextCaption(false, 999, endingCaptionNumber);
    }
}