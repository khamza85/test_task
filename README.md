## Requirements
[Get docker](https://docs.docker.com/get-docker/)

## How to use
### Spin up web site locally. Initial run takes time to download .NET Core SDK and MS SQL Server images.
`docker-compose up -d --build`

browse at http://localhost:5000/

### To stop and clean up docker resources
`docker-compose down`

## See live logs
docker logs -f synel_web_1