using System;
using System.Collections.Generic;

namespace DataStructures.Lib
{
    public class SimpleList<T>
    {
        private static readonly T[] s_emptyArray = new T[0];
        private T[] _items;
        private int _length;
        private int _currentPosition;
        
        
        
        public SimpleList(int capacity = 2)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("capacity must be positive value. Current {capacity}");
            }

            if (capacity == 0)
            {
                this._items = SimpleList<T>.s_emptyArray;
            }

            if (capacity > 0)
            {
                this._items = new T[capacity];
                this._length = capacity;
                this._currentPosition = 0;
            }
                
        }

        public int Length
        {
            get => _currentPosition;
        }
        
        

        public T this[int key]
        {
            get
            {
                return GetValue(key);
            }
            set
            {
                SetValue(key,value);
            }
        }


        
        public T GetValue(int i)
        {
            if (i < this._currentPosition )
                return this._items[i];
            else
            {
                throw new ArgumentOutOfRangeException($"Out of range. Max {_currentPosition.ToString()} got {i.ToString()}");
            }
        }

        public void SetValue(int index, T item)
        {
            if (index < _currentPosition)
            {
                _items[index] = item;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"Out of range. Max {_currentPosition.ToString()} got {index.ToString()}");
            }
        }

        public void PushValue(T item)
        {
            if (_currentPosition ==_length )
            {
                T[] newItems = new T[_length * 2];
                _items.CopyTo(newItems, 0);
                _length = _length * 2;
                
                newItems[_currentPosition++] = item;
                _items = newItems;
                return;
            }

            if (_currentPosition < _length)
            {
                _items[_currentPosition++] = item;    
                return;
            }
        }

        public T PopValue()
        {
            if (_currentPosition < 0)
            {
                throw new ArgumentOutOfRangeException($"Out of range. Trying to pop {_currentPosition.ToString()}");
            }

            if (_currentPosition < _length / 2)
            {
                T[] newItems = new T[_currentPosition];
                for (int i = 0; i < _currentPosition; i++)
                {
                    newItems[i] = _items[i];
                }
                _items = newItems;
            }
            int lastPos = _currentPosition - 1;
            T lastElement = _items[lastPos];
            _items[lastPos] = default(T);
            if (_currentPosition == _length)
            {
                _length = _currentPosition;
            }

            _currentPosition -= 1;
            return lastElement;
        }

        public void Unshift(T item)
        {
            T[] newItems = new T[_currentPosition+1];
            for (int i = 0; i < _currentPosition; i++)
            {
                newItems[i+1] = _items[i];
            }

            _currentPosition += 1;
            newItems[0] = item;

            _items = newItems;
        }

        public T Shift()
        {
            int newPosition = _currentPosition - 1;
            T[] newItems = new T[newPosition];

            for (int i = _currentPosition-1; i > 0; i--)
            {
                newItems[(i-1)] = _items[i];
            }

            T firstValue = _items[0];
            _items = newItems;

            _currentPosition = newPosition;
            
            return firstValue;

        }
            
        
    }
}