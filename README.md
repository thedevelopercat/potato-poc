# Description
This is a dummy project used for learning and experimentation purposes.

# Setup
1. Setup the infrastructure on `docker-compose` in the `infra` directory.
2. Setup the connection string for local development using:
```
    dotnet user-secrets set "ConnectionStrings:VegetablesDb" "Host=localhost;Database=garden.db;Username=<username>;Password=<password>;Port=5432;SearchPath=application" 
```