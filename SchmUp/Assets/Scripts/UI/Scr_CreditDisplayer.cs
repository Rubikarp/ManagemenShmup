using UnityEngine;
using UnityEngine.UI;

public class Scr_CreditDisplayer : MonoBehaviour
{
    [SerializeField] private Data_GameData _data = null;

    private Text _creditTextBox = null;

    private void Start()
    {
        _creditTextBox = this.gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        if(_data._credit > 99)
        {
            _creditTextBox.text = "Credit : 99+ ";
        }
        else
        {
            _creditTextBox.text = "Credit : " + _data._credit;
        }
    }
}