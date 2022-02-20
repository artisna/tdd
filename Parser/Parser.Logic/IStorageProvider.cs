using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Logic
{
    public interface IStorageProvider
    {
        void Save(File xlsxFile);
    }
}
