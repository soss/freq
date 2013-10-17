## freq

The word frequency utility.

### About

`freq` counts the words in a document and displays their frequencies.

Here is an example output of the first few results of `freq` when run over the
lyrics to
[Daft Punk's Technologic](http://www.azlyrics.com/lyrics/daftpunk/technologic.html):

    $ freq technologic.txt | head
          quick: ▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇
    technologic: ▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇
          erase: ▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇
            fix: ▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇
          trash: ▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇
         change: ▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇
           mail: ▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇
        upgrade: ▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇
         charge: ▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇
          point: ▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇▇

*NOTE: The example above excludes the word "it"*

### Mission

Your mission, if you wish to accept it, is to write `freq` based on the
following requirements:

* Read an input file (either specified by command-line arguments or from STDIN)
* Scrape out all words containing *only* letters in the english alphabet
* For simplicity's sake, convert all scraped words to lowercase
* Count the frequency of each word found
* Display the word followed by a bar representing how many times that word appears
in the document

### Scraping

Here are some edge cases you may come across:

| Input         | Expected Result |
| ------------- | --------------- |
| hello         | hello           |
| well-dressed  | well dressed    |
| Jim O'Heir    | jim oheir       |
| Hello, world! | hello world     |
| &lt;span style="float: right"&gt; | span style float right |

### Bonus

Got time to spare? Try implementing these features:

* Allow the user to specify a minimum word length
* Sort entries by frequency
* Allow the user to specify a max bar length
* If the input file is a web address, fetch the document from the web

Good luck! We're all counting on you.

---

by Jordan Scales ([http://jordanscales.com](http://jordanscales.com)). Stevens Open Source Society, Fall 2013.
