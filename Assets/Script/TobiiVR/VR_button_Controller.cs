using System.Collections;
using System.Collections.Generic;
using Tobii.XR.Examples.DevTools;
using UnityEngine;
using UnityEngine.UI;

public class VR_button_Controller : MonoBehaviour
{
    [SerializeField]  private List<VR_Button_Click> btns;

    private void Start()
    {
        ClearClicks();
    }

    public void ClearClicks()
    {
        foreach (VR_Button_Click btn in btns)
        {
            btn.clicks = 0;
            btn.fill.fillAmount = btn.clicks;
        } 
    }

    public void Btn_Was_Click(VR_Button_Click btn_c)
    {
        foreach (VR_Button_Click btn in btns)
        {
            if (btn_c != btn)
            {
                btn.clicks = 0;
                btn.fill.fillAmount = btn.clicks;
            }
        }
    }
    


}
