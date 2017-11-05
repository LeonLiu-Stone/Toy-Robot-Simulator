using System;

namespace Robots.Surfaces
{
    /// <summary>
    /// Table surface size.
    /// </summary>
    public class TableSurface : Surface
    {
        public override int minX { get { return 0; } }

        public override int maxX { get { return 5; } }

        public override int minY { get { return 0; } }

        public override int maxY { get { return 5; } }
    }
}
