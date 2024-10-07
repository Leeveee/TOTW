using Buildings;
using UnityEngine;

namespace UI
{
    public class BuildingUI : MonoBehaviour
    {
        public BuildingManager buildingManager;

        public void OnSelectHouse()
        {
            buildingManager.SelectBuilding(0); // Вибираємо будівлю за індексом 0
        }

        public void OnSelectFarm()
        {
            buildingManager.SelectBuilding(1); // Вибираємо будівлю за індексом 1
        }
    }
}