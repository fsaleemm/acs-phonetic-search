import os, json
import phoneticConfig as cfg

from azure.eventhub import EventHubConsumerClient
from azure.core.credentials import AzureKeyCredential
from azure.search.documents import SearchClient

# Connection information about Cognitive Saerch
endpoint = os.environ["SEARCH_ENDPOINT"]
key = os.environ["SEARCH_API_KEY"]
index_name = cfg.index_name

def send_to_index():

    field_name = cfg.indexField["name"]

    DOCUMENTS = [
        {
            'id': '1',
            'name': 'John',
            field_name: 'John'
        },
        {
            'id': '2',
            'name': 'harison',
            field_name: 'harison'
        },
        {
            'id': '3',
            'name': 'smith',
            field_name: 'smith'
        }
    ]


    search_client = SearchClient(endpoint, index_name, AzureKeyCredential(key))

    result = search_client.merge_or_upload_documents(documents=DOCUMENTS)
    print("Upload of new documents succeeded: {}".format(result[0].succeeded))

if __name__ == '__main__':
    send_to_index()
