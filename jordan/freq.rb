# Make sure the user specifies a file!
if ARGV.size == 0
  puts 'Specify a file pls'
  exit
end

COLUMN = 80 # Constants for the bar length
BAR = '▇' # unicode character users to print the bar

file = File.open(ARGV[0]) # Read file contents

# Replace all apostrophes with the empty string
# Replace all non-alphabetic characters with a space
# Convert everything to lower case
contents = file.read.gsub(/'/, '').gsub(/[^a-zA-Z]/, ' ').downcase
words = contents.split      # Split the string into individual tokens

freq = Hash.new(0)          # A hash whose miss value is 0

words.each do |word|
  next if word == 'it'      # skip 'it' for now...
  freq[word] += 1           # Increment the frequency of that word
end

freq_list = freq.to_a       # Convert { 'a' => 'b' } to [['a', 'b']]
freq_list.sort! { |a, b| b[1] <=> a[1] }  # Sort by frequency

max_count  = freq_list[0][1] # Get the max count to normalize our counts
max_length = freq_list.map{ |entry| entry[0].size }.max # Get the max length
                                                        # for printing purposes

freq_list.map do |entry|
  # Compute the "magnitude"
  # This is how long the bar will be
  magnitude = (entry[1] / max_count.to_f * COLUMN).to_i

  next if magnitude == 0 # skip empty bars
  printf("%#{max_length}s: %s\n", entry[0], BAR * magnitude)
end
