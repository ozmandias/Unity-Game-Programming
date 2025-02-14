using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProceduralGeneration : MonoBehaviour {
    [SerializeField] GameObject grass;
    [SerializeField] GameObject ground;
    [SerializeField] GameObject stone;
    [SerializeField] int width, height;
    [SerializeField] InputField widthField;
    [SerializeField] Button generateButton;
    bool hole = false;

    Dictionary<string, string> colors = new Dictionary<string, string>();

    void Start() {
        generateButton.onClick.AddListener(Regenerate);
        widthField.text = "" + width;
        Generate();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            // Debug.Log("Regenerate");
            Regenerate();
        }
    }

    void Generate() {
        for(int x = 0; x < width; x = x + 1) {
            do{
                height = Random.Range(height - 1, height + 2); // height = 30, min_height = 29, max_height = 32
                // int new_height = Random.Range(height - 1, height + 2);
            }while(height < 0 || height > 20);
            // Debug.Log("generate_height: " + height /*new_height*/);

            int stone_height = 0;
            stone_height = Random.Range(height - 5, height - 6);
            // Debug.Log("stone_height: " + stone_height);

            hole = Random.Range(0, 100) > 50 ? true : false;
            for(int y = 0; y < height /*new_height*/; y = y + 1) {
                // Debug.Log("generate_height: " + height + ", stone_height: " + stone_height);
                if(y < stone_height) {
                    Instantiate(stone, new Vector2(x, y), Quaternion.identity, transform);
                } else /*if(hole == false)*/ {
                    Instantiate(/*(y != height - 1) ?*/ ground /*: grass*/, new Vector2(x, y), Quaternion.identity, transform);
                }
            }
            // if(hole == false) {
                Instantiate(grass, new Vector2(x, height /*new_height*/), Quaternion.identity, transform);
            // }
        }
        gameObject.transform.position = new Vector2(0, -10);
    }

    void Regenerate() {
        width = int.Parse(widthField.text);
        DestroyGenerated();
        Generate();
    }

    void DestroyGenerated() {
        foreach(Transform child in gameObject.transform) {
            Destroy(child.gameObject);
        }
        gameObject.transform.position = new Vector2(0, 0);
    }

    void SaveColors() {
        colors.Add("grass", "#5FC314FF");
        colors.Add("ground", "#CA9A4BFF");
        colors.Add("stone", "#C2C8C9FF");
    }
}