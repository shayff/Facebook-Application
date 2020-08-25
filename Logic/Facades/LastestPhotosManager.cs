using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using Logic.Iterator;

namespace Logic.Facades
{
    public class LastestPhotosManager
    {
        private LastestPhotos r_LatestPhotos;

        public LastestPhotosManager(List<PictureBox> r_PictureBoxList, User i_LoggedinUser)
        {
            int index = 0;

            r_LatestPhotos = new LastestPhotos(i_LoggedinUser.Albums);
            IEnumerator<string> urlOfPhotosEnumerator = r_LatestPhotos.GetEnumerator();

            while (urlOfPhotosEnumerator.MoveNext() && index < r_PictureBoxList.Count)
            {
                r_PictureBoxList[index++].Load(urlOfPhotosEnumerator.Current);
            }
        }
    }
}
