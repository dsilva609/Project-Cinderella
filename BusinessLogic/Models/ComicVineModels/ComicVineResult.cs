﻿using System.Collections.Generic;

namespace BusinessLogic.Models.ComicVineModels
{
	public class ComicVineResult
	{
		public string error { get; set; }
		public int limit { get; set; }
		public int offset { get; set; }
		public int number_of_page_results { get; set; }
		public int number_of_total_results { get; set; }
		public int status_code { get; set; }
		public List<Result> results { get; set; }
		public string version { get; set; }
	}

	public class Result
	{
		public object aliases { get; set; }
		public string api_detail_url { get; set; }
		public string cover_date { get; set; }
		public string date_added { get; set; }
		public string date_last_updated { get; set; }
		public string deck { get; set; }
		public string description { get; set; }
		public object has_staff_review { get; set; }
		public string id { get; set; }
		public Image image { get; set; }
		public string issue_number { get; set; }
		public string name { get; set; }
		public string site_detail_url { get; set; }
		public string store_date { get; set; }
		public Publisher publisher { get; set; }
		public Volume volume { get; set; }
		public string resource_type { get; set; }
	}

	public class Image
	{
		public string icon_url { get; set; }
		public string medium_url { get; set; }
		public string screen_url { get; set; }
		public string small_url { get; set; }
		public string super_url { get; set; }
		public string thumb_url { get; set; }
		public string tiny_url { get; set; }
	}

	public class Volume
	{
		public string api_detail_url { get; set; }
		public int id { get; set; }
		public string name { get; set; }
		public string site_detail_url { get; set; }
	}

	public class Publisher
	{
		public string api_detail_url { get; set; }
		public int id { get; set; }
		public string name { get; set; }
	}
}