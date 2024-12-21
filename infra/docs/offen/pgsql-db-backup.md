## Scope
Backing up a PostgreSQL database involves running a script which exports the databases to a file. That file is stored in a volume which is then backed up by `offen`. This is achieved in a few steps:
1. Create a dedicated volume for backups and mount it to both `offen` and `postgres` containers.
2. On the `postgres` container, set the following 2 labels:
```
labels:
    - docker-volume-backup.archive-pre=/bin/sh /tmp/scripts/backup.sh
    - docker-volume-backup.exec-label=pgsql_database
```
Note: these labels instruct `offen` to run the `/tmp/scripts/backup.sh` before attempting to back up.
3. Set `EXEC_LABEL` in `env/offen/offen.env` to the same label value, i.e. `pgsql_database`.
4. Create the backup script in `/config/pgsql/scripts/backup.sh`:
```
#!/bin/bash
mkdir -p /tmp/pgsql_dumps && pg_dumpall -U $POSTGRES_USER -f /tmp/pgsql_dumps/backup_file_$(date +%s).sql
```
Note: The `POSTGRES_USER` has already been set when the container was started.
5. Mount the script as a read-only volume to the `postgres` container:
```
volumes:
    - ./config/pgsql/scripts:/tmp/scripts
```

## Official documentation
The official documentation is available [here](https://offen.github.io/docker-volume-backup/how-tos/run-custom-commands.html#run-custom-commands-during-the-backup-lifecycle).