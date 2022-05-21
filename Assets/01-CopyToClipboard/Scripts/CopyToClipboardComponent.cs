using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.ravio.unitylearning.copytoclipboard
{
    [RequireComponent(typeof(Button))]
    public class CopyToClipboardComponent : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        private TextMeshProUGUI copyTextField;

        private Button button;

        #endregion

        #region Mono Functions

        private void Awake()
        {
            button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            AddListeners();
        }

        private void OnDisable()
        {
            RemoveListeners();
        } 

        #endregion

        #region Listeners

        private void AddListeners()
        {
            if (button != null)
            {
                button.onClick.AddListener(HandleOnButtonClicked);
            }
        }

        private void RemoveListeners()
        {
            if (button != null)
            {
                button.onClick.RemoveListener(HandleOnButtonClicked);
            }
        }

        #endregion

        #region Copy Method

        private void CopyToClipboard()
        {
            if (copyTextField != null)
            {
                GUIUtility.systemCopyBuffer = copyTextField.text;
            }
            else if (button.GetComponentInChildren<TextMeshProUGUI>() != null)
            {
                GUIUtility.systemCopyBuffer = button.GetComponentInChildren<TextMeshProUGUI>().text;
            }
        }

        #endregion

        #region Handlers

        private void HandleOnButtonClicked()
        {
            CopyToClipboard();
        } 

        #endregion
    } 
}
