using System.Globalization;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            //Test your solutions here
            //Console.WriteLine(ExportAlbumsInfo(context, 9));
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumsByProducer = context.Producers
                .Include(a => a.Albums).ThenInclude(s => s.Songs).ThenInclude(w => w.Writer)
                .First(a => a.Id == producerId)
                .Albums.Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    a.Price,
                    Songs = a.Songs.Select(s => new
                        {
                            s.Name,
                            s.Price,
                            Writer = s.Writer.Name
                        })
                        .OrderByDescending(s => s.Name)
                        .ThenBy(s => s.Writer)
        })
                .OrderByDescending(a => a.Price)
                .AsEnumerable();

            StringBuilder sb = new StringBuilder();

            foreach (var album in albumsByProducer)
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                int songCount = 1;
                foreach (var song in album.Songs)
                {

                    sb.AppendLine($"---#{songCount++}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:F2}");
                    sb.AppendLine($"---Writer: {song.Writer}");
                }

                sb.AppendLine($"-AlbumPrice: {album.Price:F2}");
            }

            return sb.ToString().Trim();

            //var albumsInfo = context.Producers
            //    .FirstOrDefault(x => x.Id == producerId)
            //    .Albums
            //    .Select(a => new
            //    {
            //        AlbumName = a.Name,
            //        ReleaseDate = a.ReleaseDate,
            //        ProducerName = a.Producer.Name,
            //        Songs = a.Songs.Select(s => new
            //            {
            //                SongName = s.Name,
            //                SongPrice = s.Price,
            //                SongWriterName = s.Writer.Name
            //            })
            //            .OrderByDescending(s => s.SongName)
            //            .ThenBy(s => s.SongWriterName),
            //        AlbumPrice = a.Price
            //    }).OrderByDescending(a => a.AlbumPrice)
            //    .ToList();

            //var sb = new StringBuilder();

            //foreach (var album in albumsInfo)
            //{
            //    sb.AppendLine($"-AlbumName: {album.AlbumName}");
            //    sb.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy")}");
            //    sb.AppendLine($"-ProducerName: {album.ProducerName}");
            //    sb.AppendLine($"-Songs:");

            //    int counter = 1;

            //    foreach (var song in album.Songs)
            //    {
            //        sb.AppendLine($"---#{counter++}");
            //        sb.AppendLine($"---SongName: {song.SongName}");
            //        sb.AppendLine($"---Price: {song.SongPrice:f2}");
            //        sb.AppendLine($"---Writer: {song.SongWriterName}");
            //    }

            //    sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
            //}

            //return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songsAboveDuration = context.Songs
                .Where(s => s.Duration > new TimeSpan(0, 0, duration))
                .Select(s => new
                {
                    SongName = s.Name,
                    WriterName = s.Writer.Name,
                    Performers = s.SongPerformers.Select(sp => new
                    {
                        PerformerFullName = sp.Performer.FirstName + " " + sp.Performer.LastName,
                    })
                    .OrderBy(p => p.PerformerFullName).AsEnumerable(),
                    AlbumProducer = s.Album.Producer.Name,
                    SongDuration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .AsEnumerable();

            StringBuilder sb = new StringBuilder();
            int songCounter = 1;

            foreach (var song in songsAboveDuration)
            {
                sb
                    .AppendLine($"-Song #{songCounter++}")
                    .AppendLine($"---SongName: {song.SongName}")
                    .AppendLine($"---Writer: {song.WriterName}");
                if (song.Performers.Any())
                {
                    foreach (var performer in song.Performers)
                    {
                        sb.AppendLine($"---Performer: {performer.PerformerFullName}");
                    }
                }

                sb
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.SongDuration}");
            }

            return sb.ToString().Trim();
        }
    }
}
