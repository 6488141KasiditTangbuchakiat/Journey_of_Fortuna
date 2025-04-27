using TMPro;
using UnityEngine;

public class debug_tracker : MonoBehaviour
{
    public statistics player;
    public GameObject debug_buttons;

    public GameObject debug_panel;
    public TextMeshProUGUI text;

    int previous_value;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.debug_mode == 1 && previous_value != player.debug_mode)
        {
            debug_panel.SetActive(true);
            text.SetText("การมี \"เงินสำรอง\" หรือการแบ่งเงินบางส่วนไปไว้ใน \"กองทุนสำรอง\" นั้นบางทีอาจจะช่วยเราได้ในสถานการณ์ที่จำเป็น");
        }
        else if (player.debug_mode == 2 && previous_value != player.debug_mode)
        {
            debug_panel.SetActive(true);
            text.SetText("การทำประกันไว้ก็เป็นหนึ่งในวิธีการหลีกเลี่ยงการเจอเหตุการณ์ไม่คาดฝัน");
        }
        else if (player.debug_mode == 3 && previous_value != player.debug_mode)
        {
            debug_panel.SetActive(true);
            text.SetText("หากว่าที่ผ่านมายังพอมีเงินเหลือใช้ เราก็สามารถนำเงินไปลงทุนอย่างอื่นเพื่อสร้างกำไรได้ แต่ก็ต้องอย่าลืมปัจจัยสำคัญก่อนหน้านี้");
        }


        if (player.debug_mode == 4)
        {
            debug_buttons.SetActive(true);
        }
        else
        {
            debug_buttons.SetActive(false);
        }

        previous_value = player.debug_mode;
    }
}
