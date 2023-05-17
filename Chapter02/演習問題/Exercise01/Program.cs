using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {

            var songs = new Song[] {
                new Song("Let it be", "The Beatles", 243),
                new Song("Bridge Over Troubled Water", "Simon & Garfunkel", 293),
                new Song("Close To You", "Carpenters", 276),
                new Song("Honesty", "Billy Joel", 231),
                new Song("I Will Always Love You", "Whitney Houston", 273),
            };

            PrintSongs(songs);

            var lists = new List<Song>();
            lists.Add(new Song("Let it be", "The Beatles", 243));
            lists.Add(new Song("Bridge Over Troubled Water", "Simon & Garfunkel", 293));
            lists.Add(new Song("Close To You", "Carpenters", 276));
            lists.Add(new Song("Honesty", "Billy Joel", 231));
            lists.Add(new Song("I Will Always Love You", "Whitney Houston", 273));

            PrintSongs(lists);


        }

        //2.1.4
        private static void PrintSongs(IEnumerable<Song> songs) {
            foreach (var song in songs) {
                Console.WriteLine("{0},{1},{2:m\\:ss}", song.Title, song.ArtistName, TimeSpan.FromSeconds(song.Length));
            }
        }
    }
}
