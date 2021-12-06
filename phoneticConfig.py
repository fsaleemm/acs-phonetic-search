# Name of the index that is created by these scripts
index_name="phoneticindex"

# Index field name and the analyzer to setup. Give the name of the field and the phonetic analyzer name to use from the list below. 
# analyzers = "doubleMetaphone", "beiderMorse", "caverphone1", "caverphone2", "cologne", "haasePhonetik", "koelnerPhonetik", "metaphone", "nysiis", "refinedSoundex", "soundex"
# https://azuresdkdocs.blob.core.windows.net/$web/python/azure-search-documents/latest/azure.search.documents.indexes.models.html?highlight=phonetic%20encoders#azure.search.documents.indexes.models.PhoneticEncoder
indexField = {
                "name" : "phoneticname",
                "analyzer_name" : "cologne"
            }

# The tests to use for validating the phonetic analyzers
testGroups = [
    ["john", "jon", "jhon"],
    ["smith", "smyth", "schmidt"],
    ["harrison", "harison", "harisen", "herisen"],
    ["catie", "caty", "cathy", "kathy", "katie"],
    ["teresa", "theresa"],
    ["johnathan", "jonathan"]
]