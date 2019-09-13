using System;

namespace ReplaceImplicitLanguageWithInterpreter.MyWork
{
    public class Product
    {
        private readonly String _code;
        private readonly String _name;
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

        public Decimal GetPrice() => this._price;

        public ProductColor GetColor() => this._color;

        public ProductSize GetSize() => this._size;
    }
}