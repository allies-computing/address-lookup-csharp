using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using PCWCodeExamplesCSharpAddress.Models;

/*

    Address lookup with C#
    Simple demo to search for addresses via our API on form submit and returns the full address.

    Full address lookup API documentation:-
    https://developers.alliescomputing.com/postcoder-web-api/address-lookup
    
*/

namespace PCWCodeExamplesCSharpAddress.Controllers
{
	public class AddressLookupController : ApiController
    {
		[HttpGet]
		[Route("PCWCodeExamples/AddressLookup")]
		public string AddressLookup()
		{
			return "Pass a postcode or part of an address by appending /nr147pz";
		}

		[HttpGet]
		[Route("PCWCodeExamples/AddressLookup/{input}")]
		public async Task<AddressReturn> AddressLookup(string input, string countryCode = "GB", int page = 0)
		{
			// Replace with your API key, test key is locked to NR14 7PZ postcode search
			string apiKey = "PCW45-12345-12345-1234X";

			// Grab the input text and trim any whitespace
			input = input.Trim();

			// URL encode our input string
			input = HttpUtility.UrlEncode(input);

			// Create empty containers for our outputs
			List<AddressLookup> addressList = new List<AddressLookup>();
			AddressReturn output = new AddressReturn();

			if (String.IsNullOrEmpty(input))
			{
				// Respond without calling API if no input supplied
				output.error_message = "No input supplied";
			}
			else
			{
				// Create the URL to API including API key and encoded address
				string addressUrl = $"https://ws.postcoder.com/pcw/{apiKey}/address/{countryCode}/{input}?page={page.ToString()}";

				// Create a disposable HTTP client
				using (HttpClient client = new HttpClient())
				{
					// Specify "application/json" in content-type header to request json return values
					// To request XML instead, simply change to "application/xml" or remove
					client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
					
					// Execute our get request
					using (HttpResponseMessage resp = await client.GetAsync(addressUrl))
					{
						// Triggered if API does not return 200 HTTP code
						// More info - https://developers.alliescomputing.com/postcoder-web-api/error-handling

						// Here we will output a basic message with HTTP code
						if (!resp.IsSuccessStatusCode)
						{
							output.error_message = $"An error occurred - {resp.StatusCode.ToString()}";
						}
						else
						{
							// Store JSON response in our list of AddressLookup objects
							addressList = JsonConvert.DeserializeObject<List<AddressLookup>>(await resp.Content.ReadAsStringAsync());

							if (addressList.Count > 0)
							{
								// Store our list of addresses within our return wrapper
								output.addresses = addressList;

								// Store the returned page number
								output.current_page = page;

								// If the last address returned contains paging data, store it in our return wrapper
								if (output.addresses.Last().morevalues ?? false)
								{
									output.num_of_addresses = output.addresses.Last().totalresults.Value;
									output.next_page = output.addresses.Last().nextpage;
								}
								else
								{
									output.num_of_addresses = addressList.Count;
								}
							}
							else
							{
								output.error_message = "No addresses found";
							}
						}
					}
				}
			}
			
			return output;
		}
    }
}