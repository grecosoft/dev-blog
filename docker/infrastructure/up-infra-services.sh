#!/bin/bash

docker volume create --name=dev-seq_data

docker volume create --name=dev-mongo_data
docker volume create --name=dev-mongo_logs

docker volume create --name=dev-redis_data

docker volume create --name=dev-rabbit_data
docker volume create --name=dev-rabbit_logs

docker volume create --name=dev-sql-server_data

docker-compose up -d

