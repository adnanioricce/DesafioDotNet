#! /bin/docker
docker stop desafiodotnet;docker rm desafiodotnet;docker stop desafiodotnetdb;docker rm desafiodotnetdb;
docker build . -t adnanioricce/desafiodotnet -f DesafioDotNet/Dockerfile; 
docker build DesafioDotNet/SQL/ -t adnanioricce/desafiodotnetdb;
docker run -dt --name desafiodotnetdb -p 1233:1433 adnanioricce/desafiodotnetdb;
docker run -dt --name desafiodotnet -p 6060:80 -e "DATABASE_URL=Server=host.docker.internal,1233;Database=DesafioDb;User Id=sa;Password=!P4ssword;" adnanioricce/desafiodotnet;
