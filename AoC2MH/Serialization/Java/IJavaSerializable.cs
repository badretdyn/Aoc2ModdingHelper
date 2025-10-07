using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2mh.Serialization.Java
{
    public interface IJavaSerializable
    {
        string FileName { get; set; }

        byte[] GetTcString();
    }
}
