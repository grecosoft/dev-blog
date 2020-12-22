for NODE in `seq 1 6`; do
  NODE_NAME="node-${NODE}"
  docker-machine rm --force $NODE_NAME
done  
 
