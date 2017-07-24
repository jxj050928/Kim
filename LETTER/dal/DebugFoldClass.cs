using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal
{
    public static class DebugFoldClass
    {
        public static string Debugfole
        {
            get { return DbHeapPer.FileFold.XmlPath; }
            set { DbHeapPer.FileFold.XmlPath = value; }
        }
    }
}
