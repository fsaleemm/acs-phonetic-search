# Azure Cognitive Search - Phonetic Search

This repo contains scripts to setup an index with phonetic search to help evaluate and benchmark the [phonetic encoders](https://docs.microsoft.com/en-us/dotnet/api/azure.search.documents.indexes.models.phoneticencoder?view=azure-dotnet).

## Pre-work

1. Python 3.6 or later
1. Azure Sbuscription is needed.
1. Setup the [Azure Cognitive Search service](https://docs.microsoft.com/en-us/azure/search/search-create-service-portal).

## Setup the Environment

### Install Python Packages

Install Azure Cognitive Search packages

```bash
pip install azure-search-documents
```

### Setup Variables

Setup the Cognitive Search connection information environment variables.

```bash
export SEARCH_ENDPOINT="<Your Azure Cognitive Search Endpoint>"
export SEARCH_API_KEY="<Your Search API Key>"
```

## Run the Sample Code

Run the Create Phonetic Index script. This script will setup an index with the name provided in the phoneticConfig.py file. Additionally, it will create the 11 analyzers with the phonetic encoding options available.

```bash
python3 createPhoneticIndex.py
```

Output:

```bash
Starting Index Creation
Completed index Creation
```

Go to the Azure portal, find your Azure Cognitive Search service, go to the indexes and click on the "phoneticindex" and look at the Index Definition, you will see the analyzers setup. See below screenshot for reference.

![index definition](/images/s1.png)

Run the evaluation benchmark for the phonetic encoders.

```bash
python3 analyzerTest.py
```

output:

```bash
############################## Analyzer: 'doubleMetaphone' ################################

 john	=>	JN
 jon	=>	JN
 jhon	=>	JN

The match ratio is: 1.0 

 smith	=>	SM0
 smyth	=>	SM0
 schmidt	=>	XMT

The match ratio is: 0.6666666666666666 

 harrison	=>	HRSN
 harison	=>	HRSN
 harisen	=>	HRSN
 herisen	=>	HRSN

The match ratio is: 1.0 

 catie	=>	KT
 caty	=>	KT
 cathy	=>	K0
 kathy	=>	K0
 katie	=>	KT

The match ratio is: 0.6 

 teresa	=>	TRS
 theresa	=>	0RS

The match ratio is: 0 

 johnathan	=>	JN0N
 jonathan	=>	JN0N

The match ratio is: 1.0 

############################## Analyzer: 'beiderMorse' ################################

 john	=>	ion
 jon	=>	ion
 jhon	=>	ion

The match ratio is: 1.0 

 smith	=>	zmit
 smyth	=>	zmit
 schmidt	=>	stzmit

The match ratio is: 0.6666666666666666 

 harrison	=>	arison
 harison	=>	arison
 harisen	=>	YrQsn
 herisen	=>	YrQsn

The match ratio is: 0.5 

 catie	=>	kYti
 caty	=>	kati
 cathy	=>	kYti
 kathy	=>	kYti
 katie	=>	kYti

The match ratio is: 0.8 

 teresa	=>	tYrYsa
 theresa	=>	tYrYsa

The match ratio is: 1.0 

 johnathan	=>	ionYtan
 jonathan	=>	ionYtan

The match ratio is: 1.0 

############################## Analyzer: 'caverphone1' ################################

 john	=>	YN1111
 jon	=>	YN1111
 jhon	=>	N11111

The match ratio is: 0.6666666666666666 

 smith	=>	SMT111
 smyth	=>	SMT111
 schmidt	=>	SKMT11

The match ratio is: 0.6666666666666666 

 harrison	=>	ARSN11
 harison	=>	ARSN11
 harisen	=>	ARSN11
 herisen	=>	ARSN11

The match ratio is: 1.0 

 catie	=>	KT1111
 caty	=>	KT1111
 cathy	=>	KT1111
 kathy	=>	KT1111
 katie	=>	KT1111

The match ratio is: 1.0 

 teresa	=>	TRS111
 theresa	=>	TRS111

The match ratio is: 1.0 

 johnathan	=>	YNTN11
 jonathan	=>	YNTN11

The match ratio is: 1.0 

############################## Analyzer: 'caverphone2' ################################

 john	=>	YN11111111
 jon	=>	YN11111111
 jhon	=>	AN11111111

The match ratio is: 0.6666666666666666 

 smith	=>	SMT1111111
 smyth	=>	SMT1111111
 schmidt	=>	SKMT111111

The match ratio is: 0.6666666666666666 

 harrison	=>	ARSN111111
 harison	=>	ARSN111111
 harisen	=>	ARSN111111
 herisen	=>	ARSN111111

The match ratio is: 1.0 

 catie	=>	KTA1111111
 caty	=>	KTA1111111
 cathy	=>	KTA1111111
 kathy	=>	KTA1111111
 katie	=>	KTA1111111

The match ratio is: 1.0 

 teresa	=>	TRSA111111
 theresa	=>	TRSA111111

The match ratio is: 1.0 

 johnathan	=>	YNTN111111
 jonathan	=>	YNTN111111

The match ratio is: 1.0 

############################## Analyzer: 'cologne' ################################

 john	=>	06
 jon	=>	06
 jhon	=>	06

The match ratio is: 1.0 

 smith	=>	862
 smyth	=>	862
 schmidt	=>	862

The match ratio is: 1.0 

 harrison	=>	0786
 harison	=>	0786
 harisen	=>	0786
 herisen	=>	0786

The match ratio is: 1.0 

 catie	=>	42
 caty	=>	42
 cathy	=>	42
 kathy	=>	42
 katie	=>	42

The match ratio is: 1.0 

 teresa	=>	278
 theresa	=>	278

The match ratio is: 1.0 

 johnathan	=>	0626
 jonathan	=>	0626

The match ratio is: 1.0 

############################## Analyzer: 'haasePhonetik' ################################

 john	=>	96
 jon	=>	96
 jhon	=>	96

The match ratio is: 1.0 

 smith	=>	862
 smyth	=>	862
 schmidt	=>	862

The match ratio is: 1.0 

 harrison	=>	9786
 harison	=>	9786
 harisen	=>	9786
 herisen	=>	9786

The match ratio is: 1.0 

 catie	=>	42
 caty	=>	42
 cathy	=>	42
 kathy	=>	42
 katie	=>	42

The match ratio is: 1.0 

 teresa	=>	278
 theresa	=>	278

The match ratio is: 1.0 

 johnathan	=>	9626
 jonathan	=>	9626

The match ratio is: 1.0 

############################## Analyzer: 'koelnerPhonetik' ################################

 john	=>	06
 jon	=>	06
 jhon	=>	06

The match ratio is: 1.0 

 smith	=>	862
 smyth	=>	862
 schmidt	=>	862

The match ratio is: 1.0 

 harrison	=>	0786
 harison	=>	0786
 harisen	=>	0786
 herisen	=>	0786

The match ratio is: 1.0 

 catie	=>	42
 caty	=>	42
 cathy	=>	42
 kathy	=>	42
 katie	=>	42

The match ratio is: 1.0 

 teresa	=>	278
 theresa	=>	278

The match ratio is: 1.0 

 johnathan	=>	0626
 jonathan	=>	0626

The match ratio is: 1.0 

############################## Analyzer: 'metaphone' ################################

 john	=>	JN
 jon	=>	JN
 jhon	=>	JHN

The match ratio is: 0.6666666666666666 

 smith	=>	SM0
 smyth	=>	SM0
 schmidt	=>	SKMT

The match ratio is: 0.6666666666666666 

 harrison	=>	HRSN
 harison	=>	HRSN
 harisen	=>	HRSN
 herisen	=>	HRSN

The match ratio is: 1.0 

 catie	=>	KT
 caty	=>	KT
 cathy	=>	K0
 kathy	=>	K0
 katie	=>	KT

The match ratio is: 0.6 

 teresa	=>	TRS
 theresa	=>	0RS

The match ratio is: 0 

 johnathan	=>	JN0N
 jonathan	=>	JN0N

The match ratio is: 1.0 

############################## Analyzer: 'nysiis' ################################

 john	=>	JAN
 jon	=>	JAN
 jhon	=>	JAN

The match ratio is: 1.0 

 smith	=>	SNAT
 smyth	=>	SNYT
 schmidt	=>	SNAD

The match ratio is: 0 

 harrison	=>	HARASA
 harison	=>	HARASA
 harisen	=>	HARASA
 herisen	=>	HARASA

The match ratio is: 1.0 

 catie	=>	CATY
 caty	=>	CATY
 cathy	=>	CATY
 kathy	=>	CATY
 katie	=>	CATY

The match ratio is: 1.0 

 teresa	=>	TARAS
 theresa	=>	TARAS

The match ratio is: 1.0 

 johnathan	=>	JANATA
 jonathan	=>	JANATA

The match ratio is: 1.0 

############################## Analyzer: 'refinedSoundex' ################################

 john	=>	J408
 jon	=>	J408
 jhon	=>	J408

The match ratio is: 1.0 

 smith	=>	S38060
 smyth	=>	S38060
 schmidt	=>	S30806

The match ratio is: 0.6666666666666666 

 harrison	=>	H090308
 harison	=>	H090308
 harisen	=>	H090308
 herisen	=>	H090308

The match ratio is: 1.0 

 catie	=>	C3060
 caty	=>	C3060
 cathy	=>	C3060
 kathy	=>	K3060
 katie	=>	K3060

The match ratio is: 0.6 

 teresa	=>	T609030
 theresa	=>	T609030

The match ratio is: 1.0 

 johnathan	=>	J4080608
 jonathan	=>	J4080608

The match ratio is: 1.0 

############################## Analyzer: 'soundex' ################################

 john	=>	J500
 jon	=>	J500
 jhon	=>	J500

The match ratio is: 1.0 

 smith	=>	S530
 smyth	=>	S530
 schmidt	=>	S530

The match ratio is: 1.0 

 harrison	=>	H625
 harison	=>	H625
 harisen	=>	H625
 herisen	=>	H625

The match ratio is: 1.0 

 catie	=>	C300
 caty	=>	C300
 cathy	=>	C300
 kathy	=>	K300
 katie	=>	K300

The match ratio is: 0.6 

 teresa	=>	T620
 theresa	=>	T620

The match ratio is: 1.0 

 johnathan	=>	J535
 jonathan	=>	J535

The match ratio is: 1.0 

Summary of score in descending order
Analyzer: cologne => Score: 6.0
Analyzer: haasePhonetik => Score: 6.0
Analyzer: koelnerPhonetik => Score: 6.0
Analyzer: soundex => Score: 5.6
Analyzer: caverphone1 => Score: 5.333333333333333
Analyzer: caverphone2 => Score: 5.333333333333333
Analyzer: refinedSoundex => Score: 5.266666666666667
Analyzer: nysiis => Score: 5.0
Analyzer: beiderMorse => Score: 4.966666666666667
Analyzer: doubleMetaphone => Score: 4.266666666666667
Analyzer: metaphone => Score: 3.933333333333333
```

Based on the scenarios defined in the phoneticConfig.py, the benchmark shows that the best option for phonetic analyzer is either cologne, haasePhonetik, or koelnerPhonetik

You can modify the test groups in the phoneticConfig.py file to match your phonetic search scenarios to determine the best analyzer to use.

```python
# phoneticConfig.py
# The tests to use for validating the phonetic analyzers
testGroups = [
    ["john", "jon", "jhon"],
    ["smith", "smyth", "schmidt"],
    ["harrison", "harison", "harisen", "herisen"],
    ["catie", "caty", "cathy", "kathy", "katie"],
    ["teresa", "theresa"],
    ["johnathan", "jonathan"]
]
```
