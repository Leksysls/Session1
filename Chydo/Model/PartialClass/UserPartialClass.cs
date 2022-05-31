using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Chydo.Model
{
   public partial class User
    {
        public string FIO
        {
            get
            {
                return $"{UserSurname} {UserName} {UserPatronymic}";
            }
        }

        public Visibility VisibilityUser
        {
            get
            {
                if (App.CurrentUser !=null)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
        }
    }
}
