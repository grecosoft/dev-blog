#!/bin/bash

docker-machine create --driver virtualbox node-1
docker-machine create --driver virtualbox node-2
docker-machine create --driver virtualbox node-3
docker-machine create --driver virtualbox node-4
docker-machine create --driver virtualbox node-5
docker-machine create --driver virtualbox node-6

# Initialize the Swarm and obtain the join token:
export IP=$(docker-machine ip node-1)
docker-machine ssh node-1 docker swarm init --advertise-addr $IP
export JOIN_TOKEN=$(docker-machine ssh node-1 docker swarm join-token worker -q)

# Join the remaining VMs to the swarm:
docker-machine ssh node-2 docker swarm join --token $JOIN_TOKEN $IP:2377
docker-machine ssh node-3 docker swarm join --token $JOIN_TOKEN $IP:2377
docker-machine ssh node-4 docker swarm join --token $JOIN_TOKEN $IP:2377
docker-machine ssh node-5 docker swarm join --token $JOIN_TOKEN $IP:2377
docker-machine ssh node-6 docker swarm join --token $JOIN_TOKEN $IP:2377

# Promote two of the nodes so they are managers:
docker-machine ssh node-1 docker node promote node-2 node-3

# Label one of the nodes to run containers containing services dependent
# on state storage:
docker-machine ssh node-1 docker node update --label-add type=infra node-6

# Create the needed storage volumes:
docker-machine ssh node-6 docker volume create --name=dev-seq_data
docker-machine ssh node-6 docker volume create --name=dev-rabbit_data
docker-machine ssh node-6 docker volume create --name=dev-rabbit_logs
docker-machine ssh node-6 docker volume create --name=dev-mongo_data
docker-machine ssh node-6 docker volume create --name=dev-mongo_logs

# Copy the RabbitMQ configuration:
docker-machine ssh node-6 mkdir rabbit
docker-machine scp -r infrastructure/rabbit/ node-6:~/





