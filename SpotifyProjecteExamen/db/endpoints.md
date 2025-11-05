# Profiles

POST http://localhost:5000/profiles

{
  "name": "perfil1",
   "description": "descripció",
    "State": "actiu"
}

GET http://localhost:5000/profiles

GET"byid" http://localhost:5000/profiles/id

PUT http://localhost:5000/profiles/id

{
  "name": "perfileditat",
   "description": "descripcioeditada",
    "State": "inactiu"
}

DELETE http://localhost:5000/profiles/id

# Images

POST http://localhost:5000/images

{
  "url": "https://github.com/marcsoler897/DAM",
      "name": "pinturaclasse",
   "description": "descripcióimatge",
    "type": "png"
}

GET http://localhost:5000/images

GET"byid" http://localhost:5000/images/id

PUT http://localhost:5000/images/id

{
  "url": "https://github.com/marcsoler897/DAM",
      "name": "pinturaclasseeditada",
   "description": "descripcióimatgeeditada",
    "type": "pngeditat"
}

DELETE http://localhost:5000/images/id