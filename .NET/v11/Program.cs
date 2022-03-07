// See https://aka.ms/new-console-template for more information
using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using System.Runtime.CompilerServices;

namespace ACSIndexeCreation
{
    class IndexCreator
    {
        public static void CreatePhoneticIndex(string indexname, Uri endpoint, string key)
        {
            AzureKeyCredential credential = new AzureKeyCredential(key);

            SearchClientOptions options = new SearchClientOptions();

            SearchIndexClient client = new SearchIndexClient(endpoint, credential);

            SearchIndex index = new SearchIndex(indexname)
            {
                Fields =
                {
                    new SimpleField("id", SearchFieldDataType.String) { IsKey = true, IsFilterable = true, IsSortable = true },
                    new SearchableField("name") { IsFilterable = true, AnalyzerName = LexicalAnalyzerName.EnMicrosoft },
                    new SearchableField("phoneticname") { IsFilterable = true, AnalyzerName = "cologne" },

                },
                TokenFilters =
                {
                    new PhoneticTokenFilter("doubleMetaphone")
                    {
                        Encoder = PhoneticEncoder.DoubleMetaphone
                    },
                    new PhoneticTokenFilter("beiderMorse")
                    {
                        Encoder = PhoneticEncoder.BeiderMorse
                    },
                    new PhoneticTokenFilter("caverphone1")
                    {
                        Encoder = PhoneticEncoder.Caverphone1
                    },
                    new PhoneticTokenFilter("caverphone2")
                    {
                        Encoder = PhoneticEncoder.Caverphone2
                    },
                    new PhoneticTokenFilter("cologne")
                    {
                        Encoder = PhoneticEncoder.Cologne
                    },
                    new PhoneticTokenFilter("haasePhonetik")
                    {
                        Encoder = PhoneticEncoder.HaasePhonetik
                    },
                    new PhoneticTokenFilter("koelnerPhonetik")
                    {
                        Encoder = PhoneticEncoder.KoelnerPhonetik
                    },
                    new PhoneticTokenFilter("metaphone")
                    {
                        Encoder = PhoneticEncoder.Metaphone
                    },
                    new PhoneticTokenFilter("nysiis")
                    {
                        Encoder = PhoneticEncoder.Nysiis
                    },
                    new PhoneticTokenFilter("refinedSoundex")
                    {
                        Encoder = PhoneticEncoder.RefinedSoundex
                    },
                    new PhoneticTokenFilter("soundex")
                    {
                        Encoder = PhoneticEncoder.Soundex
                    }

                },
                Analyzers =
                {
                    new CustomAnalyzer("doubleMetaphone","microsoft_language_tokenizer")
                    {
                        TokenFilters = { TokenFilterName.Lowercase, TokenFilterName.AsciiFolding, "doubleMetaphone" }
                    },
                    new CustomAnalyzer("beiderMorse","microsoft_language_tokenizer")
                    {
                        TokenFilters = { TokenFilterName.Lowercase, TokenFilterName.AsciiFolding, "beiderMorse" }
                    },
                    new CustomAnalyzer("caverphone1","microsoft_language_tokenizer")
                    {
                        TokenFilters = { TokenFilterName.Lowercase, TokenFilterName.AsciiFolding, "caverphone1" }
                    },
                    new CustomAnalyzer("caverphone2","microsoft_language_tokenizer")
                    {
                        TokenFilters = { TokenFilterName.Lowercase, TokenFilterName.AsciiFolding, "caverphone2" }
                    },
                    new CustomAnalyzer("cologne","microsoft_language_tokenizer")
                    {
                        TokenFilters = { TokenFilterName.Lowercase, TokenFilterName.AsciiFolding, "cologne" }
                    },
                    new CustomAnalyzer("haasePhonetik","microsoft_language_tokenizer")
                    {
                        TokenFilters = { TokenFilterName.Lowercase, TokenFilterName.AsciiFolding, "haasePhonetik" }
                    },
                    new CustomAnalyzer("koelnerPhonetik","microsoft_language_tokenizer")
                    {
                        TokenFilters = { TokenFilterName.Lowercase, TokenFilterName.AsciiFolding, "koelnerPhonetik" }
                    },
                    new CustomAnalyzer("metaphone","microsoft_language_tokenizer")
                    {
                        TokenFilters = { TokenFilterName.Lowercase, TokenFilterName.AsciiFolding, "metaphone" }
                    },
                    new CustomAnalyzer("nysiis","microsoft_language_tokenizer")
                    {
                        TokenFilters = { TokenFilterName.Lowercase, TokenFilterName.AsciiFolding, "nysiis" }
                    },
                    new CustomAnalyzer("refinedSoundex","microsoft_language_tokenizer")
                    {
                        TokenFilters = { TokenFilterName.Lowercase, TokenFilterName.AsciiFolding, "refinedSoundex" }
                    },
                    new CustomAnalyzer("soundex","microsoft_language_tokenizer")
                    {
                        TokenFilters = { TokenFilterName.Lowercase, TokenFilterName.AsciiFolding, "soundex" }
                    }
                }
            };

            client.DeleteIndex(indexname);
            client.CreateIndex(index);            
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string? searchEndpoint = Environment.GetEnvironmentVariable("SEARCH_ENDPOINT");
                string? key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");
                string indexname = "phoneticindex";

                if (searchEndpoint == null || key == null)
                {
                    Console.WriteLine("Please setup the environment variables SEARCH_ENDPOINT and SEARCH_API_KEY and try again.");
                    Environment.Exit(-1);
                }
                    
                Uri endpoint = new Uri(searchEndpoint);

                Console.WriteLine("Starting Index Creation: " + indexname);

                //Create an index with a custom Analyzer using the Cologne Phonetic encoder.
                IndexCreator.CreatePhoneticIndex(indexname, endpoint, key);

                Console.WriteLine("Completed index Creation: " + indexname);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Something went wrong. Exception is: " + ex.Message);
                Environment.Exit(-1);
            }

        }
    }

}







