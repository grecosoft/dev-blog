#!/bin/bash

docker image rm blgreco72dev/ref-arch-srv:latest -f
docker image rm ref-arch-srv:latest -f

docker build -t ref-arch-srv  ./RefMicroServ

docker tag ref-arch-srv:latest blgreco72dev/ref-arch-srv:latest
docker push blgreco72dev/ref-arch-srv:latest
