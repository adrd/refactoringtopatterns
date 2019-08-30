using System;

namespace ReplaceOneOrManyDistinctionsWithComposite.MyWork
{
    public class Product
    {
        private String _code;
        private String _name;
        private readonly ProductColor _color;
        private readonly Decimal _price;
        private readonly ProductSize _size;

        public Product(String code, String name, ProductColor color, Decimal price, ProductSize size)
        {
            this._code = code;
            this._name = name;
            this._color = color;
            this._price = price;
            this._size = size;
        }

        public Decimal Price => this._price;

        public ProductColor Color => this._color;

        public ProductSize Size => this._size;
    }
}