# -------------------------------------------------------------------------------------------------
# Reference Architecture: Microservice environment specific configurations
# -------------------------------------------------------------------------------------------------
#
# Create a config-map with entries from the configuration files for the corresponding environment.
# These configuration files contain information that need not be stored as secrets. The pod
# definition maps the config-map to a volume where each entry is a file. When the microservice
# starts, each file is added to the .net core configuration-builder.

# Multiple configration fies can be used for each section of the microservice's overall configuration
# (i.e. SEQ, RabbitMQ, MongoDB...) to keep things organized.
#
# Each environment for a given microservice based solution (dev, test, qa, and prod) have
# corresponding kubernete's namespaces to which the config-maps and volums are scoped.
#
# NOTE: Could have a convention named config-map containing default/common settings across all
# micoservice contained within a given solution namespace. The volumn containing these default
# configuration would need to be added first to the .net core configuration builder so default
# settings can be overriden by a specific microservice configuration.

kubectl create configmap app-settings -n ref-arch-dev \
--from-file=../microservice/Configs/dev/connections.json \
--from-file=../microservice/Configs/dev/processors.json

kubectl create -f ./pod-resource.yaml -n ref-arch-dev
