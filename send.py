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
        },
        {
            'id': '4',
            'name': 'smyth',
            field_name: 'smyth'
        },
        {
            'id': '5',
            'name': 'schmidt',
            field_name: 'schmidt'
        },
        {
            'id': '6',
            'name': 'jon',
            field_name: 'jon'
        },
        {
            'id': '7',
            'name': 'jovan',
            field_name: 'jovan'
        },
        {
            'id': '8',
            'name': 'juan',
            field_name: 'juan'
        },
        {
            'id': '9',
            'name': 'johnathan',
            field_name: 'johnathan'
        },
        {
            'id': '10',
            'name': 'giovani',
            field_name: 'giovani'
        },
        {
            'id': '11',
            'name': 'zane',
            field_name: 'zane'
        },
        {
            'id': '12',
            'name': 'kana',
            field_name: 'kana'
        },
        {
            'id': '13',
            'name': 'djohnie',
            field_name: 'djohnie'
        },
        {
            'id': '14',
            'name': 'keon',
            field_name: 'keon'
        }
    ]


    search_client = SearchClient(endpoint, index_name, AzureKeyCredential(key))

    result = search_client.merge_or_upload_documents(documents=DOCUMENTS)
    print("Upload of new documents succeeded: {}".format(result[0].succeeded))

if __name__ == '__main__':
    send_to_index()
