using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentTransferCoreImpl
{
    class DGValueManager
    {
        private Dictionary<string, string> _originalCellValues;
        private Dictionary<string, string> _currentCellValues;

        public DGValueManager()
        {
            _originalCellValues = new Dictionary<string, string>();
            _currentCellValues = new Dictionary<string, string>();
        }

        public void AddCellValue(int rowIdx, int colIdx, string Value)
        {
            string key = GenerateKey(rowIdx, colIdx);

            _originalCellValues.Add(key, Value);
            _currentCellValues.Add(key, Value);
        }

        public void SetCellValue(int rowIdx, int colIdx, string Value)
        {
            string key = GenerateKey(rowIdx, colIdx);

            if (_currentCellValues.ContainsKey(key))
                _currentCellValues[key] = Value;
            else
            {
                if (!_originalCellValues.ContainsKey(key))
                {
                    _originalCellValues.Add(key, "");
                    _currentCellValues.Add(key, Value);
                }
            }
        }

        public bool IsDirty()
        {
            foreach (string key in _originalCellValues.Keys)
            {
                if (_currentCellValues[key] != _originalCellValues[key])
                    return true;
            }
            return false;
        }

        public void Clear()
        {
            _originalCellValues.Clear();
            _currentCellValues.Clear();
        }

        private string GenerateKey(int rowIndex, int colIndex)
        {
            return "R" + rowIndex + "C" + colIndex;
        }
    }
}