using UnityEngine;

public class deck_mechanics : MonoBehaviour
{

    public card[] deck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public card drawCard()
    {
        int num = Random.Range(0, deck.Length);

        return deck[num];
    }
}
