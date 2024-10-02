using UnityEngine;

namespace Buildings
{
    [RequireComponent(typeof(Clickable))]
    public abstract class Building : MonoBehaviour
    {
       
        private Clickable _clickable;
        public abstract eBuildingType Type { get; }

        private void Awake()
        {
            _clickable = GetComponent<Clickable>();
            _clickable.OnClicked += ClickOnBuild;
        }

        private void ClickOnBuild()
        {
            Debug.Log(Type);
        }
    }
}