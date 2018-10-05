using UnityEngine;
using UnityEngine.UI;

//Made By Anthony Romrell
namespace ArtisanDream.Tools.DataStorage.Examples.Scripts
{
    public class TextUI : MonoBehaviour
    {
        public InputField DataField;
        public Text DataOutputText;

        public DataStorage NameDataStorage;

        public StringData SoData;

        private void Start()
        {
            NameDataStorage.GetData();
            DataOutputText.text = SoData.SingleName;
        }

        public void UpdateText()
        {
            SoData.SingleName = DataField.text;
            DataOutputText.text = SoData.SingleName;
            NameDataStorage.SetData();
        }
    }
}