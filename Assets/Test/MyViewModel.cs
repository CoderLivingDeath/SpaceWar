using UnityEngine;
using UnityEngine.UIElements;
namespace Assets.Test
{
    public class MyViewModel : MonoBehaviour
    {
        public UIDocument document;
        public string text;

        public Label label;

        private void Start()
        {
            label = document.rootVisualElement.Q<Label>("text_test");
        }

        private void Update()
        {
            label.text = text;
        }
    }
}
