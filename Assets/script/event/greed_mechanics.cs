using UnityEngine;

public class greed_mechanics : MonoBehaviour
{

    public greed_card[] greed_deck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    greed_card drawCard()
    {
        int num = Random.Range(0, greed_deck.Length);

        return greed_deck[num];
    }
}
