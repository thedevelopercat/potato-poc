# Description
This is a dummy project used for learning and experimentation purposes.

# Dependecies
1. PostgreSQL

`docker run --name some-postgres -e POSTGRES_PASSWORD=mysecretpassword -d postgres
`
```
docker run --name "potato_pgsql_dev" -e POSTGRES_USER="potato" -e POSTGRES_PASSWORD="Aw3someP0tato2024!" -e POSTGRES_DB="vegetables.db" -p 5432:5432 -v potatoPgSqlDev:/var/log/postgresql/ -d --restart unless-stopped postgres:17-alpine 
```