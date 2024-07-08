using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ICTOAN
{
    public class PageOrganiser
    {
        public Dictionary<Type, object> PageList = new();

        /*  Include all required Page / Items here and add them to the list.  */
        /* ex:
            public PageOrganiser(MainPage main, GamePage game)
            {
                addToList(main);
                addToList(game);
            }
        */
        public PageOrganiser()
        {

        }

        private void addToList(object pa)
        {
            PageList.Add(pa.GetType(), pa);
        }
    }
}
