using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateImage
{
    interface IProccess
    {
        string readAndModificate(string imageFile);
        Task<string> readAndModificateAsync(string imageFile);
    }
}
