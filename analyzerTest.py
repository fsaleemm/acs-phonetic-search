import os

from statistics import mode
from azure.core.credentials import AzureKeyCredential
from azure.search.documents.indexes import SearchIndexClient
from azure.search.documents.indexes.models import AnalyzeTextOptions

import phoneticConfig as cfg

service_endpoint = os.getenv("SEARCH_ENDPOINT")
index_name = cfg.index_name
key = os.getenv("SEARCH_API_KEY")

analyzers = ["doubleMetaphone", "beiderMorse", "caverphone1", "caverphone2", "cologne", "haasePhonetik", "koelnerPhonetik", "metaphone", "nysiis", "refinedSoundex", "soundex"]


def simple_analyze_text(text, analyzer_name):

    client = SearchIndexClient(service_endpoint, AzureKeyCredential(key))

    analyze_request = AnalyzeTextOptions(text=text, analyzer_name=analyzer_name)

    result = client.analyze_text(index_name, analyze_request)

    return result.as_dict()['tokens'][0]['token'] 
    

def common_match_ratio(list):
    mfv_count = list.count(mode(list))

    if mfv_count > 1:
        return int(mfv_count)/len(list)
    else:
        return 0


def run_test():
    summary_ratios = {}

    for analyzer in analyzers:
        print("############################## Analyzer: %a ################################\n" %analyzer)
        summary_ratios[analyzer] = 0

        for testGroup in cfg.testGroups:
            
            encoded_list = []

            for val in testGroup:
                token = simple_analyze_text(val, analyzer)
                encoded_list.append(token)
                print(" %s\t=>\t%s" %(val,token))
            
            match_ratio = common_match_ratio(encoded_list)
            summary_ratios[analyzer] += match_ratio


            print("\nThe match ratio is: %s \n" %str(match_ratio))
    
    sorted_summary_ratios = sorted(summary_ratios.items(), key=lambda x:x[1], reverse=True)

    print("Summary of score in descending order")
    for ratio in sorted_summary_ratios:
        print("Analyzer: %s => Score: %s" %(ratio[0], ratio[1]))

if __name__ == '__main__':
    run_test()