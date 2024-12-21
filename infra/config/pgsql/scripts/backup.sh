#!/bin/bash
mkdir -p /tmp/pgsql_dumps && pg_dumpall -U $POSTGRES_USER -f /tmp/pgsql_dumps/backup_file_$(date +%s).sql