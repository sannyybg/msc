using muscshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace muscshop
{
    public class FakeDatabase
    {
        private List<Album> _albums;
        private List<Genre> _genres;
        private List<Artist> _artists;

        public List<Album> Albums
        {
            get { return _albums; }
        }

        public List<Artist> Artists

        {
            get { return _artists; }
        }

        public List<Genre> Genres
        {
            get { return _genres; }
        }

        public FakeDatabase()
        {
            InitializeArtists();
            InitializeGenres();
            InitializeAlbums();
        }



        private void InitializeArtists()
        {
            _artists = new List<Artist>();

            _artists.Add(new Artist() { Name = "Daft Punk", ImageUrl = "dfurl", ArtistId = 1, BasicInfo = "info" });
            _artists.Add(new Artist() { Name = "Linkin Park", ImageUrl = "dfurl", ArtistId = 2, BasicInfo = "info" });
            _artists.Add(new Artist() { Name = "Pink Floyd", ImageUrl = "dfurl", ArtistId = 3, BasicInfo = "info" });
            _artists.Add(new Artist() { Name = "Led Zeppelin", ImageUrl = "dfurl", ArtistId = 4, BasicInfo = "info" });
            _artists.Add(new Artist() { Name = "2pac", ImageUrl = "dfurl", ArtistId = 5, BasicInfo = "info" });
            _artists.Add(new Artist() { Name = "Moby", ImageUrl = "dfurl", ArtistId = 5, BasicInfo = "info" });
            _artists.Add(new Artist() { Name = "Drake", ImageUrl = "dfurl", ArtistId = 7, BasicInfo = "info" });
            _artists.Add(new Artist() { Name = "Sia", ImageUrl = "dfurl", ArtistId = 8, BasicInfo = "info" });
            _artists.Add(new Artist() { Name = "Dr. Dre", ImageUrl = "dfurl", ArtistId = 9, BasicInfo = "info" });
            _artists.Add(new Artist() { Name = "Coldplay", ImageUrl = "dfurl", ArtistId = 10, BasicInfo = "info" });
            _artists.Add(new Artist() { Name = "Notorious Big", ImageUrl = "dfurl", ArtistId = 11, BasicInfo = "info" });
            _artists.Add(new Artist() { Name = "Eminem", ImageUrl = "dfurl", ArtistId = 12, BasicInfo = "info" });
            _artists.Add(new Artist() { Name = "Rammstein", ImageUrl = "dfurl", ArtistId = 13, BasicInfo = "info" });
            _artists.Add(new Artist() { Name = "Mac Miller", ImageUrl = "dfurl", ArtistId = 14, BasicInfo = "info" });



        }

        private void InitializeGenres()
        {
            _genres = new List<Genre>();

            _genres.Add(new Genre() { Name = "Rap", GenreId = 1 });
            _genres.Add(new Genre() { Name = "Electronic", GenreId = 2 });
            _genres.Add(new Genre() { Name = "R-B", GenreId = 3 });
            _genres.Add(new Genre() { Name = "Hip-Hop", GenreId = 4 });
            _genres.Add(new Genre() { Name = "Alternative Rock", GenreId = 5 });
            _genres.Add(new Genre() { Name = "Pop", GenreId = 6 });
            _genres.Add(new Genre() { Name = "Classic", GenreId = 7 });
            _genres.Add(new Genre() { Name = "Progressive Rock", GenreId = 8 });
            _genres.Add(new Genre() { Name = "Techno", GenreId = 9 });
            _genres.Add(new Genre() { Name = "House", GenreId = 10 });

        }

        private void InitializeAlbums()
        {
            _albums = new List<Album>();

            _albums.Add(new Album()
            {
                AlbumId = 1,
                Title = "Human after all",
                Price = 18,
                AlbumUrl = "/myFiles/images/human.jpg",
                ReleaseYear = 2002,
                Artist = _artists.Where(x => x.Name == "Daft Punk").FirstOrDefault(),
                Genre = _genres.Where(x => x.Name == "Electronic").FirstOrDefault()

            });

            _albums.Add(new Album()
            {
                AlbumId = 2,
                Title = "Compton",
                Price = 17,
                AlbumUrl = "/myFiles/images/compton.jpg",
                ReleaseYear = 2015,
                Artist = _artists.Where(x => x.Name == "Dr. Dre").FirstOrDefault(),
                Genre = _genres.Where(x => x.Name == "Rap").FirstOrDefault()

            });

            _albums.Add(new Album()
            {
                AlbumId = 3,
                Title = "Viva La Vida",
                Price = 13.99,
                AlbumUrl = "/myFiles/images/viva.jpg",
                ReleaseYear = 2005,
                Artist = _artists.Where(x => x.Name == "Coldplay").FirstOrDefault(),
                Genre = _genres.Where(x => x.Name == "Alternative Rock").FirstOrDefault()

            });

            _albums.Add(new Album()
            {
                AlbumId = 4,
                Title = "Changes",
                Price = 15.70,
                AlbumUrl = "/myFiles/images/changes.jpg",
                ReleaseYear = 1991,
                Artist = _artists.Where(x => x.Name == "2pac").FirstOrDefault(),
                Genre = _genres.Where(x => x.Name == "Rap").FirstOrDefault()

            });

            _albums.Add(new Album()
            {
                AlbumId = 5,
                Title = "MM Songs",
                Price = 21.99,
                AlbumUrl = "mmill",
                ReleaseYear = 2009,
                Artist = _artists.Where(x => x.Name == "Mac Miller").FirstOrDefault(),
                Genre = _genres.Where(x => x.Name == "R-B").FirstOrDefault()

            });

            _albums.Add(new Album()
            {
                AlbumId = 6,
                Title = "8 Mile",
                Price = 17.50,
                AlbumUrl = "mnm",
                ReleaseYear = 2002,
                Artist = _artists.Where(x => x.Name == "Eminem").FirstOrDefault(),
                Genre = _genres.Where(x => x.Name == "Hip-Hop").FirstOrDefault()

            });


            _albums.Add(new Album()
            {
                AlbumId = 7,
                Title = "Chndelier",
                Price = 18,
                AlbumUrl = "sia",
                ReleaseYear = 2012,
                Artist = _artists.Where(x => x.Name == "Sia").FirstOrDefault(),
                Genre = _genres.Where(x => x.Name == "Pop").FirstOrDefault()

            });


           
        }

        public void UpdateAlbum(Album updateAlbum)
        {
            
            updateAlbum.Genre = Genres.Where(x => x.GenreId == updateAlbum.GenreId).FirstOrDefault();
            updateAlbum.Artist = Artists.Where(x => x.ArtistId == updateAlbum.ArtistId).FirstOrDefault();

            _albums[updateAlbum.AlbumId - 1] = updateAlbum;
        }

        public void AddAlbum(Album newalbum)
        {
            newalbum.Genre = Genres.Where(x => x.GenreId == newalbum.GenreId).FirstOrDefault();
            newalbum.Artist = Artists.Where(x => x.ArtistId == newalbum.ArtistId).FirstOrDefault();
            newalbum.AlbumId = _albums.Max(x => x.AlbumId) + 1;
            _albums.Add(newalbum);
        }
    }

}