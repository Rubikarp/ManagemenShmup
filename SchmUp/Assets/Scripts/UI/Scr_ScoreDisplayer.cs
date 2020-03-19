using UnityEngine;
using UnityEngine.UI;

public class Scr_ScoreDisplayer : MonoBehaviour
{
    [SerializeField] private Data_GameData _data = null;

    private Text _scoreTextBox = null;

    private void Start()
    {
        _scoreTextBox = this.gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        _scoreTextBox.text = "Score: " + _data._score;
    }

}
