﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MvcMusicStore.Models
{

    public class Album
    {
        [ScaffoldColumn(false)]
        [BindNever]
        public int AlbumId { get; set; }
        [DisplayName("Genre")]
        public int GenreId { get; set; }
        [DisplayName("Artist")]
        public int ArtistId { get; set; }
        public string Title { get; set; }
        [Range(0.01, 100.00, ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }
        [DisplayName("Album Art URL")]
        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }
        public virtual Genre? Genre { get; set; }
        public virtual Artist? Artist { get; set; }
    }
}
