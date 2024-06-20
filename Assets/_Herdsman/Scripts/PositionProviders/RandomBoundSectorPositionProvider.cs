﻿using System.Collections.Generic;
using UnityEngine;

namespace Herdsman.PositionProviders
{
    public class RandomBoundSectorPositionProvider : IPositionProvider
    {
        private readonly int _sectorSize;
        private readonly Bounds _allowedAreaBounds;
        private readonly Bounds _restrictedAreaBounds;
        private readonly List<Vector2Int> _possiblePositions;

        public RandomBoundSectorPositionProvider(int sectorSize, Bounds allowedAreaBounds, Bounds restrictedAreaBounds)
        {
            _sectorSize = sectorSize;
            _allowedAreaBounds = allowedAreaBounds;
            _restrictedAreaBounds = restrictedAreaBounds;
            _possiblePositions = new List<Vector2Int>();

            CalculatePossiblePositions();
        }

        private void CalculatePossiblePositions()
        {
            // calculate possible positions substracting restricted area from allowed area keeping in mind sector size

            // Get the min and max points of the allowed area
            var allowedMin = _allowedAreaBounds.min;
            var allowedMax = _allowedAreaBounds.max;

            // Get the min and max points of the restricted area
            var restrictedMin = _restrictedAreaBounds.min;
            var restrictedMax = _restrictedAreaBounds.max;

            // Iterate over all positions within the allowed bounds
            for (int x = Mathf.FloorToInt(allowedMin.x / _sectorSize) * _sectorSize; x <= Mathf.FloorToInt(allowedMax.x / _sectorSize) * _sectorSize; x += _sectorSize)
            {
                for (int y = Mathf.FloorToInt(allowedMin.y / _sectorSize) * _sectorSize; y <= Mathf.FloorToInt(allowedMax.y / _sectorSize) * _sectorSize; y += _sectorSize)
                {
                    var position = new Vector2Int(x, y);

                    // Check if the position is outside the restricted area
                    if (position.x < restrictedMin.x || position.x > restrictedMax.x ||
                        position.y < restrictedMin.y || position.y > restrictedMax.y)
                    {
                        _possiblePositions.Add(position);
                    }
                }
            }
        }

        public Vector2 GetPosition()
        {
            return _possiblePositions.Count == 0 ? 
                Vector2.zero : 
                _possiblePositions[UnityEngine.Random.Range(0, _possiblePositions.Count)]; 
        }
    }
}