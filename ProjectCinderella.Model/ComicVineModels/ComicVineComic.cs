using System.Collections.Generic;

namespace ProjectCinderella.Model.ComicVineModels
{
	public class ComicVineComic
	{
		public string error { get; set; }
		public int limit { get; set; }
		public int offset { get; set; }
		public int number_of_page_results { get; set; }
		public int number_of_total_results { get; set; }
		public int status_code { get; set; }
		public Results results { get; set; }
		public string version { get; set; }
	}

	public class Results
	{
		public object aliases { get; set; }
		public string api_detail_url { get; set; }
		public List<Character_Credits> character_credits { get; set; }
		public string cover_date { get; set; }
		public string date_added { get; set; }
		public string date_last_updated { get; set; }
		public object deck { get; set; }
		public string description { get; set; }
		public List<First_Appearance_Characters> first_appearance_characters { get; set; }
		public object first_appearance_concepts { get; set; }
		public List<First_Appearance_Locations> first_appearance_locations { get; set; }
		public object first_appearance_objects { get; set; }
		public object first_appearance_storyarcs { get; set; }
		public List<First_Appearance_Teams> first_appearance_teams { get; set; }
		public bool has_staff_review { get; set; }
		public int id { get; set; }
		public Image image { get; set; }
		public string issue_number { get; set; }
		public List<Location_Credits> location_credits { get; set; }
		public string name { get; set; }
		public List<Person_Credits> person_credits { get; set; }
		public string site_detail_url { get; set; }
		public object store_date { get; set; }
		public List<Team_Credits> team_credits { get; set; }
		public Publisher publisher { get; set; }
	}

	public class Character_Credits
	{
		public string api_detail_url { get; set; }
		public int id { get; set; }
		public string name { get; set; }
		public string site_detail_url { get; set; }
	}

	public class First_Appearance_Characters
	{
		public string api_detail_url { get; set; }
		public int id { get; set; }
		public string name { get; set; }
		public string site_detail_url { get; set; }
	}

	public class First_Appearance_Locations
	{
		public string api_detail_url { get; set; }
		public int id { get; set; }
		public string name { get; set; }
		public string site_detail_url { get; set; }
	}

	public class First_Appearance_Teams
	{
		public string api_detail_url { get; set; }
		public int id { get; set; }
		public string name { get; set; }
		public string site_detail_url { get; set; }
	}

	public class Location_Credits
	{
		public string api_detail_url { get; set; }
		public int id { get; set; }
		public string name { get; set; }
		public string site_detail_url { get; set; }
	}

	public class Person_Credits
	{
		public string api_detail_url { get; set; }
		public int id { get; set; }
		public string name { get; set; }
		public string site_detail_url { get; set; }
		public string role { get; set; }
	}

	public class Team_Credits
	{
		public string api_detail_url { get; set; }
		public int id { get; set; }
		public string name { get; set; }
		public string site_detail_url { get; set; }
	}
}