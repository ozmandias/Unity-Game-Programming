using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Text suggestionText;
    public static UIManager instance;

    void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    void Start() {
        DontDestroyOnLoad(this.gameObject);
        ClearSuggestionText();
    }

    public void SetSuggestionText(string _text) {
        suggestionText.text = _text;
    }

    public void ClearSuggestionText() {
        suggestionText.text = "";
    }
}