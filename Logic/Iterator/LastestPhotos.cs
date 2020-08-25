using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace Logic.Iterator
{
    internal class LastestPhotos : IEnumerable
    {
        private readonly FacebookObjectCollection<Album> r_AlbumCollection;

        public LastestPhotos(FacebookObjectCollection<Album> i_AlbumCollection)
        {
            r_AlbumCollection = i_AlbumCollection;
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (Album album in r_AlbumCollection)
            {
                foreach (Photo photo in album.Photos)
                {
                    yield return photo.PictureThumbURL;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
