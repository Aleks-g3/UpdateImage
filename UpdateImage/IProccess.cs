using System.Drawing;

namespace UpdateImage
{
    interface IProccess
    {
        string readAndModify(string path,string imageFile);
    }
}
