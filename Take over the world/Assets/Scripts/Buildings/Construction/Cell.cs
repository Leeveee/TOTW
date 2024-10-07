using System;
using Reactive;
using UnityEngine;

namespace Buildings.Construction
{
    public class Cell : MonoBehaviour
    {
        public ReactiveBool IsFreeCell;

        private void Awake()
        {
            IsFreeCell = new ReactiveBool(true);
        }
    }
}