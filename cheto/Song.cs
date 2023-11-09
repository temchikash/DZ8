using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    internal class Song
    {
        private string name_song { get; set; }
        private string author_song { get; set; }
        public Song prev_song { get; set; }
        
        public Song()
        {

        }
        public Song(string name, string author)
        {
            this.name_song = name;
            this.author_song = author;
            prev_song = null;
        }
        public Song(string name,string author,Song prev)
        {
            this.name_song = name;
            this.author_song = author;
            this.prev_song = prev;
        }
        

        public void SongName()
        {
            Console.WriteLine("Название композиции :");
            name_song = Console.ReadLine();
            Console.WriteLine("Песня добавлена ");
        }
        public void SongAuthor()
        {
            Console.WriteLine("Введите автора песни :");
            author_song = Console.ReadLine();
            Console.WriteLine("Автор добавлен");
        }
        public void Previous(List<Song>list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].SongName();
                list[i].SongAuthor();
                if (i != 0)
                {
                    list[i].prev_song = list[i - 1];
                }
                else
                {
                    Console.WriteLine("Предыдущей песни нет - это первая в списке\n");
                }
                

            }
        }
        public string Print()
        {
            string InfoSong = name_song + "" + author_song;
            return InfoSong;
        }
        public override bool Equals(object obj)
        {
            Song composition = obj as Song;
            if (composition != null && (composition.name_song == name_song) && (composition.author_song == author_song))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
