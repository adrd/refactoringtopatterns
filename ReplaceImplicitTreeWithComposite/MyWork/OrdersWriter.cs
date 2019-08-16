using System;
using System.Text;

namespace ReplaceImplicitTreeWithComposite.MyWork
{
    public class OrdersWriter
    {
        private readonly Orders _orders;

        public OrdersWriter(Orders orders)
        {
            this._orders = orders;
        }

        // Example of Compose Method
        public String GetContents()
        {
            StringBuilder xml = new StringBuilder();
            this.WriteOrderTo(xml);
            return xml.ToString();
        }

        private void WriteOrderTo(StringBuilder xml)
        {
            TagNode ordersNode = new TagNode("orders");

            for (Int32 i = 0; i < this._orders.OrderCount(); i++)
            {
                Order order = this._orders.Order(i);

                TagNode orderNode = new TagNode("order");
                orderNode.AddAttribute("id", order.OrderId().ToString());

                this.WriteProductsTo(orderNode, order);

                ordersNode.Add(orderNode);   // add child node to parent node
            }

            xml.Append(ordersNode.ToString());
        }

        private void WriteProductsTo(TagNode orderNode, Order order)
        {
            for (Int32 j = 0; j < order.ProductCount(); j++)
            {
                Product product = order.Product(j);

                TagNode productNode = new TagNode("product");
                productNode.AddAttribute("id", product.ID.ToString());
                productNode.AddAttribute("color", this.ColorFor(product));

                if (product.Size != (Int32) ProductSize.NotApplicable)
                {
                    productNode.AddAttribute("size", this.SizeFor(product));
                }

                this.WritePriceTo(productNode, product);
                
                productNode.AddValue(product.Name);

                orderNode.Add(productNode);  // add child node to parent node
            }
        }

        private void WritePriceTo(TagNode productNode, Product product)
        {
            TagNode priceNode = new TagNode("price");

            priceNode.AddAttribute("currency", this.CurrencyFor(product));
            priceNode.AddValue(product.Price);

            productNode.Add(priceNode);  // add child node to parent node
        }

        private string CurrencyFor(Product product)
        {
            // I made the assumption that all products will be in USD for 
            // this example
            return "USD";
        }

        private string SizeFor(Product product)
        {
            // I've made the assumption that all sizes will be a medium
            // for this example
            switch (product.Size)
            {
                case ProductSize.Medium:
                    return "medium";
                default:
                    return "NOT APPLICABLE";
            }
        }

        private string ColorFor(Product product)
        {
            // I made the assumption that all products are red for this example
            return "red";
        }
    }
}