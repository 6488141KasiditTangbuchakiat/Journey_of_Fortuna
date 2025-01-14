using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class partner_pool : MonoBehaviour
{
    [SerializeField]
    public List<partner> PartnerList = new List<partner>();

    //public partner[] partner_list;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public partner random_one_partner()
    {
        // cut out the selected

        if (PartnerList.Count > 0)
        {
            int num = Random.Range(0, PartnerList.Count);

            partner selected_partner = PartnerList[num];

            PartnerList.RemoveAt(num);


            return selected_partner;
        }

        return null;

    }
}
