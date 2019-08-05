using System;

namespace ComposeMethod.MyWork
{
    public class List
    {
        private Boolean _readOnly;
        private Int32 _size;
        private Object[] _elements = new Object[] { };

        private static readonly Int32 GrowthIncrement = 10;

        public void Add(Object element)
        {
            if (this._readOnly) 
                return;

            if (this.AtCapacity()) 
                this.Grow();

            this.AddElement(element);
        }

        private Boolean AtCapacity()
        {
            return this._size + 1 > this._elements.Length;
        }

        private void Grow()
        {
            Object[] newElements = new Object[this._elements.Length + List.GrowthIncrement];

            for (int i = 0; i < this._size; i++)
                newElements[i] = this._elements[i];

            this._elements = newElements;
        }

        private void AddElement(Object element)
        {
            this._elements[this._size++] = element;
        }

        public Int32 Count
        {
            get
            {
                return this._size;
            }
        }
    }
}
