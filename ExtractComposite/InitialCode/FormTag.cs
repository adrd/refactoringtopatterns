using System;
using System.Collections.Generic;
using System.Text;

namespace ExtractComposite.InitialCode
{
    public class FormTag : Tag
    {
        protected Node[] _allNodesVector;
        
        public String ToPlainTextString()
        {
            StringBuilder stringRepresentation = new StringBuilder();

            foreach (Node node in this.GetAllNodesVector())
            {
                stringRepresentation.Append(node.ToPlainTextString());
            }

            return stringRepresentation.ToString();
        }

        private IEnumerable<Node> GetAllNodesVector()
        {
            throw new NotImplementedException();
        }
    }
}