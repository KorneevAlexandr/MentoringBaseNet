using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tree
{
    public class FileNode : TreeNode
    {
        public FileNode(string name)
            : base(name)
        {
        }

        public override bool IsComposite()
        {
            return false;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
