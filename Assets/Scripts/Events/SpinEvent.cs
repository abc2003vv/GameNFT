using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.PickerWheelUI;
using UnityEngine.UI;
public class SpinEvent : MonoBehaviour
{
    [SerializeField] private Button spinUI;
    [SerializeField] private Text UIspinButtonText;
    [SerializeField] private PickerWheel pickerWheel;
    // Start is called before the first frame update
    void Start()
    {
        spinUI.onClick.AddListener(() =>
        {
            UIspinButtonText.text = "Sping";
            pickerWheel.Spin();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
