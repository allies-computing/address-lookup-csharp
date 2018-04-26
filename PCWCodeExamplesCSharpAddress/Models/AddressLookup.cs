using System.Collections.Generic;
using Newtonsoft.Json;

namespace PCWCodeExamplesCSharpAddress.Models
{
	/// <summary>
	/// For storing the results of an address lookup
	/// </summary>
	[JsonObject]
	public class AddressLookup
	{
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string summaryline { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string pobox { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string organisation { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string departmentname { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string builidingname { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string subbuildingname { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string premise { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string dependentstreet { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string street { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string doubledependentlocality { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string dependentlocality { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string posttown { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string county { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string postcode { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string recodes { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? morevalues { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? nextpage { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? totalresults { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? alias { get; set; }
	}

	/// <summary>
	/// A wrapper class for returning the results of an address lookup 
	/// with some summary information included
	/// </summary>
	[JsonObject]
	public class AddressReturn
	{
		[JsonProperty]
		public int num_of_addresses { get; set; }

		[JsonProperty]
		public int current_page { get; set; }
		
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int? next_page { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string error_message { get; set; }

		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public List<AddressLookup> addresses { get; set; }
	}
}