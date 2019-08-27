using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ExtractComposite.InitialCode
{
    public class LinkTag : Tag
    {
        private Node[] _nodeVector;

        public String ToPlainTextString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Node node in this.LinkData())
            {
                sb.Append(node.ToPlainTextString());
            }

            return sb.ToString();
        }

        private IEnumerable<Node> LinkData()
        {
            throw new NotImplementedException();
        }
    }
}
