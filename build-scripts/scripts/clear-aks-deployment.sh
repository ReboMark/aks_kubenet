echo "Deleting Deployments ($SERVICE)"
output_pods=$(az aks command invoke \
    -g $RG \
    -n $AKS \
    --command "kubectl delete deployment $SERVICE-dep --namespace=$NAMESPACE")