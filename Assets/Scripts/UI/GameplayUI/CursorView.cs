using TMPro;
using UnityEngine;

namespace GameplayUI
{
    public class CursorView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _text;
        [SerializeField] RectTransform _cursor;
        
        public void SetInteractive(bool isInteracting)
        {
            if(isInteracting)
            {
                _cursor.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            }
            else
            {
                _cursor.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
        }
        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}
