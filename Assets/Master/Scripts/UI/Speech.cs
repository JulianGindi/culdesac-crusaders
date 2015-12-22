using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Speech : MonoBehaviour {

    public GameObject speechCanvas;
    public Transform SpeechBubble;

    private const int WIDTH = 640;
    private const int VERTICAL_PADDING = 64;
    private const int VERTICAL_OFFSET = 64;
    private const int CHARS_PER_LINE = 32;
    private const int HEIGHT_PER_LINE = 32;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Speak"))
        {
            Speak();
        }
    }

    IEnumerator Speak() {
        string phrases = System.IO.File.ReadAllText("Assets/Master/Text/sample_speech.txt");
        string[] phrasesArr = phrases.Split('\n');
        string phrase = phrasesArr[Random.Range(0, phrasesArr.Length - 1)];
        int numberOfLines = phrase.Length / CHARS_PER_LINE;

        Vector2 positioning = Camera.main.WorldToScreenPoint(transform.position);
        Transform newElement = Instantiate(SpeechBubble);
        newElement.transform.Find("Speech").GetComponent<Text>().text = phrase;

        RectTransform rt = newElement.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(WIDTH, (numberOfLines * HEIGHT_PER_LINE) + VERTICAL_PADDING);
        rt.anchoredPosition = new Vector2(positioning.x, positioning.y + VERTICAL_OFFSET);

        newElement.SetParent(speechCanvas.transform);
        yield return new WaitForSeconds(5);
        Destroy(newElement.gameObject);
    }

}
