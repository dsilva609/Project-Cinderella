﻿using System;

namespace ProjectCinderella.Model.Common
{
    public class ServiceSettings
    {
	    public string GiantBombKey { get; set; }
	    public string DiscogsKey { get; set; }
	    public string TMDBKey { get; set; }
	    public string ComicVineKey { get; set; }
		public DateTime RecordStoreDayDate { get; set;}
	    public DateTime FreeComicBookDayDate { get; set; }
    }
}