using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class partner_pool : MonoBehaviour
{
    [SerializeField]
    public List<partner> PartnerList_veryRare = new List<partner>();
    public List<partner> PartnerList_rare = new List<partner>();
    public List<partner> PartnerList_common = new List<partner>();

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

        int partner_all = PartnerList_veryRare.Count + PartnerList_rare.Count + PartnerList_common.Count;

        if (partner_all > 0)
        {
            int chance = Random.Range(1, 100);
            partner selected_partner = null;

            print(chance);

            if (chance >= 0 && chance < 5 && PartnerList_veryRare.Count > 0)
            {
                // very rare partner

                print("very rare partner");

                int num = Random.Range(0, PartnerList_veryRare.Count);
                selected_partner = PartnerList_veryRare[num];
                PartnerList_veryRare.RemoveAt(num);

            }
            else if (chance >= 5 && chance < 30 && PartnerList_rare.Count > 0)
            {
                // rare partner

                print("rare partner");

                int num = Random.Range(0, PartnerList_rare.Count);
                selected_partner = PartnerList_rare[num];
                PartnerList_rare.RemoveAt(num);

            }
            else if (chance >= 30 && chance < 100 && PartnerList_common.Count > 0)
            {
                //common partner

                print("common partner");

                int num = Random.Range(0, PartnerList_common.Count);
                selected_partner = PartnerList_common[num];
                PartnerList_common.RemoveAt(num);
            }
            else
            {
                // pity system
                if (PartnerList_common.Count > 0)
                {
                    int num = Random.Range(0, PartnerList_common.Count);
                    selected_partner = PartnerList_common[num];
                    PartnerList_common.RemoveAt(num);

                }
                else if (PartnerList_rare.Count > 0)
                {
                    int num = Random.Range(0, PartnerList_rare.Count);
                    selected_partner = PartnerList_rare[num];
                    PartnerList_rare.RemoveAt(num);

                }
                else if (PartnerList_veryRare.Count > 0)
                {
                    int num = Random.Range(0, PartnerList_veryRare.Count);
                    selected_partner = PartnerList_veryRare[num];
                    PartnerList_veryRare.RemoveAt(num);

                }
            }


            /*
            int num = Random.Range(0, PartnerList.Count);

            selected_partner = PartnerList[num];

            PartnerList.RemoveAt(num);
            */

            return selected_partner;
        }



        return null;

    }
}
