using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab1
{
    class Node
    {
        public int id { get; }
        public Vector2 coords { get; }

        public Node(int id, float x, float y)
        {
            this.id = id;
            this.coords = new Vector2(x, y);
        }
    }
}
