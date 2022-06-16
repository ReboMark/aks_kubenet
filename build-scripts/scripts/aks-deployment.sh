envsubst < ./build-scripts/manifest/deployment.yml > ./build-scripts/manifest/aks_deployment.yml
envsubst < ./build-scripts/manifest/service.yml > ./build-scripts/manifest/aks_service.yml
envsubst < ./build-scripts/manifest/ingress.yml > ./build-scripts/manifest/aks_ingress.yml

ls ./build-scripts/manifest/aks-manifest/

cat $GITHUB_WORKSPACE/build-scripts/manifest/aks_deployment.yml
echo
cat $GITHUB_WORKSPACE/build-scripts/manifest/aks_service.yml
echo
cat $GITHUB_WORKSPACE/build-scripts/manifest/aks_ingress.yml

az aks command invoke \
    -g $RG \
    -n $AKS \
    --command "kubectl apply -f deployment.yml -n $NAMESPACE" \
    --file $GITHUB_WORKSPACE/build-scripts/manifest/aks_deployment.yml

az aks command invoke \
    -g $RG \
    -n $AKS \
    --command "kubectl apply -f service.yml -n $NAMESPACE" \
    --file $GITHUB_WORKSPACE/build-scripts/manifest/aks_service.yml


az aks command invoke \
    -g $RG \
    -n $AKS \
    --command "kubectl apply -f ingress.yml -n $NAMESPACE" \
    --file $GITHUB_WORKSPACE/build-scripts/manifest/aks_ingress.yml

rm ./build-scripts/manifest/aks_deployment.yml
rm ./build-scripts/manifest/aks_service.yml
rm ./build-scripts/manifest/aks_ingress.yml