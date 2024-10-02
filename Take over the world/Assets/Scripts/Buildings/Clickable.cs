using System;
using UnityEngine;

namespace Buildings
{
    public class Clickable : MonoBehaviour
    {
        public event Action OnClicked;

        private void OnMouseUpAsButton()
        {
            OnClicked?.Invoke();
        }
    }
}