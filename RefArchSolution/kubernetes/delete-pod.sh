#!/bin/bash

kubectl delete -f ./pod-resource.yaml -n ref-arch-dev
kubectl delete configmap app-settings -n ref-arch-dev
kubectl delete secret app-secrets -n ref-arch-dev
