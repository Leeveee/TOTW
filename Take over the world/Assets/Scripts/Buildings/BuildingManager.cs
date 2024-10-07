using System;
using Buildings.Construction;
using UnityEngine;

namespace Buildings
{
    public class BuildingManager : MonoBehaviour
    {
        public Building [] buildingPrefabs;
        public int [] buildingCosts;
        public int playerResources = 1000;

        private Building _currentBuilding;
        private bool _isPlacing;

        private void Update()
        {
            if (_isPlacing)
            {
                MoveBuildingToMouse();
            }
        }
        
        public void SelectBuilding (int index)
        {
            if (playerResources >= buildingCosts[index])
            {
                playerResources -= buildingCosts[index];
                _currentBuilding = Instantiate(buildingPrefabs[index]);
                _currentBuilding.OnPlacedComplete.Value = false;
                _isPlacing = true;
            }
            else
            {
                Debug.Log("Недостатньо ресурсів!");
            }
        }
        
        private void MoveBuildingToMouse()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                switch (_currentBuilding.Type)
                {
                    case eBuildingType.MainBuilding or eBuildingType.Tavern:
                        if (hit.collider.TryGetComponent(out TownCell townCell))
                            GetNeededCell(townCell, hit);
                        break;

                    case eBuildingType.Tower:
                        if (hit.collider.TryGetComponent(out TowerCell towerCell))
                            GetNeededCell(towerCell, hit);
                        break;

                    default:
                        Debug.Log("Невідомий тип будівлі");
                        break;
                }
                // if (hit.collider.TryGetComponent(out Cell cell))
                // {
                //     GetNeededCell(cell, hit);
                // }
            }
        }

        private void GetNeededCell (Cell cell, RaycastHit hit)
        {
            if (cell.IsFreeCell)
            {
                _currentBuilding.transform.position = hit.collider.transform.position;

                if (Input.GetMouseButtonDown(0))
                {
                    PlaceBuilding(cell);
                }
            }
        }

        private void PlaceBuilding (Cell cell)
        {
            _currentBuilding.OnPlacedComplete.Value = true;
            cell.IsFreeCell.Value = false;
            _isPlacing = false;
            _currentBuilding = null;
        }
    }
}