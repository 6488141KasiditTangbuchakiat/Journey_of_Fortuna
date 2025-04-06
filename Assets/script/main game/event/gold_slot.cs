using TMPro;
using UnityEngine;

public class gold_slot : MonoBehaviour
{
    public statistics player;
    public gold_card thisCard;

    public TextMeshProUGUI card_name;
    public TextMeshProUGUI card_desc;
    public TextMeshProUGUI value;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        card_name.SetText($"{thisCard.title}");
        card_desc.SetText($"{thisCard.description}");

        if (thisCard.money_gain > 0)
        {
            value.SetText($"{thisCard.money_gain.ToString("N0")}");
        }
        else if (thisCard.energy_boost > 0)
        {
            value.SetText($"{thisCard.energy_boost}");
        }
        else if (thisCard.expense_reduction > 0)
        {
            value.SetText($"{thisCard.expense_reduction}");
        }

    }

    public void add_benefits()
    {
        if (thisCard.money_gain > 0)
        {
            player.addMoney(thisCard.money_gain);
        }
        else if (thisCard.energy_boost > 0)
        {
            player.energy_cap_buff += thisCard.energy_boost;
        }
        else if (thisCard.expense_reduction > 0)
        {
            player.cost_reduce_buff += thisCard.expense_reduction;
        }
    }
}
