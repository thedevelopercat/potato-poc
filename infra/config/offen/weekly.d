BACKUP_FILENAME="weekly-backup-%Y-%m-%dT%H-%M-%S.tar.gz"
# run every monday at 3am
BACKUP_CRON_EXPRESSION="0 3 * * 1"
BACKUP_PRUNING_PREFIX="weekly-backup-"
BACKUP_RETENTION_DAYS="14"