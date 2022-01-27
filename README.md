# CloudTraining : Sync vs Async communication
 Microservices in Azure

## Sync
---

### Pro 

- Easy to do
- In an architecture where there is dependency between services sync calls should be there in order to work
- Instant feedback if failed/succeded

### Cons

- In an architecture where services don't depend on each other this can produce performance issues because services have to wait for each other even if there is no need to do so
- Timeout posibility due to high load 
- In case a service is down(unavailable) other services that are dependant fail also

## Async
---

### Pro

- Independance between services
- Persistance for messags between services
- Fire and forget

### Cons

- Dependant on the service bus / queue system
