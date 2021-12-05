using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba11._1
{
    class Song
    {
        string name;
        string author;
        Song prev;

        public Song(string _name, string _author)
        {
            name = _name;
            author = _author;
            prev = null;
        }
         public Song(string _name, string _author, Song _prev)
        {
            name = _name;
            author = _author;
            prev = _prev;
        }
        public Song()
        {

        }
        public string songName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string songAuthor
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }
        public void setPrev(Song song)
        {
            prev = song;
        }
        public string Title()
        {
            return $"{name} - {author}";
        }
        public override bool Equals(object d)
        {
            if (d.GetType() == GetType())
                return true;
            else
                return false;
        }
    }
}
