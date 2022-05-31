using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chydo.Model
{
    public partial class Product
    {
        public string MainPhoto
        {
            get
            {
                if (ProductPhoto != null)
                {
                    return $"\\Assets\\Image\\Tovar\\" + ProductPhoto.Trim();
                }
                else
                    return $"\\Assets\\Image\\picture.png";
            }
        }
    }
}
