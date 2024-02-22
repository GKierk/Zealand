import json

myDictionary = {
  "ID": 1,
  "Name": "Tony Stark",
  "Age": 53,
  "Description": "Genius, billionaire, playboy, philanthropist",
}

saveData = json.dumps(myDictionary, indent=2)

with open("3-semester/Teknologi/Uge 5/data.json", "w") as file:
  file.write(saveData)
  file.close()

loadData = open("3-semester/Teknologi/Uge 5/data.json", "r")
data = json.loads(loadData.read())
loadData.close()

print(data)

loadData = open("3-semester/Teknologi/Uge 5/other.json", "r")
data = json.loads(loadData.read())
loadData.close()

print(data["Employees"][0]["Name"])
print(data["Cars"][1]["Color"])