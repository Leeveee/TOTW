using System;
using System.Runtime.CompilerServices;
using Reactive;
using UnityEngine;

namespace Buildings
{
    [RequireComponent(typeof(Clickable))]
    public abstract class Building : MonoBehaviour
    {
        private Clickable _clickable;
        private BoxCollider _boxCollider;
        public abstract eBuildingType Type { get; }
        public ReactiveBool OnPlacedComplete = new ReactiveBool(false);

        private void Awake()
        {
            _clickable = GetComponent<Clickable>();
            _boxCollider = GetComponent<BoxCollider>();
            OnPlacedComplete.OnChanged += ActivateCollider;
            _clickable.OnClicked += ClickOnBuild;
        }

        private void OnDestroy()
        {
            OnPlacedComplete.OnChanged -= ActivateCollider;
            _clickable.OnClicked -= ClickOnBuild;
        }

        private void ClickOnBuild()
        {
            Debug.Log(Type);
        }

        private void ActivateCollider(bool value)
        {
            _boxCollider.enabled = value;
        }
    }
}