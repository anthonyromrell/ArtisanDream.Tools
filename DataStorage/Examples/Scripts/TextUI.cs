using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

//Made By Anthony Romrell

    public class TextUi : MonoBehaviour
    {
        [FormerlySerializedAs("DataField")] public InputField dataField;
        [FormerlySerializedAs("DataOutputText")] public Text dataOutputText;

        [FormerlySerializedAs("NameDataStorage")] public DataStorage nameDataStorage;

        [FormerlySerializedAs("SoData")] public StringData soData;

        private void Start()
        {
            nameDataStorage.GetData();
            dataOutputText.text = soData.SingleName;
        }

        public void UpdateText()
        {
            soData.SingleName = dataField.text;
            dataOutputText.text = soData.SingleName;
            nameDataStorage.SetData();
        }
    }
