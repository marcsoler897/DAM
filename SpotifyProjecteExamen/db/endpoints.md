POST http://localhost:5000/profiles

{
  "name": "perfil1",
   "description": "descripció",
    "State": "actiu"
}

GET http://localhost:5000/profiles

GET http://localhost:5000/profiles/id

PUT http://localhost:5000/profiles/id

{
  "name": "perfileditat",
   "description": "descripcioeditada",
    "State": "inactiu"
}

DELETE http://localhost:5000/profiles/id