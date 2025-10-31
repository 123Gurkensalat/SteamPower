import json

# Define coordinate ranges
x_range = range(2, -3, -1)  #
y_range = range(4, 1, -1)  #
z_range = range(4, 1, -1)  #

# x_range = range(3, -4, -1)
# y_range = range(3, 1, -1)
# z_range = range(5, 0, -1)
# Generate all offsets
offsets = [
    {"x": x, "y": y, "z": z, "w": 2}
    for y in y_range  #
    for x in x_range
    for z in z_range
]

# Wrap into JSON structure
data = {"offsets": offsets}

filename = "offsets_full_pipe.json"
message = "✅ File saved as " + filename + " with "
# Save to a file
with open(filename, "w") as f:
    json.dump(data, f, indent=2)

print(message, len(offsets), "entries.")
