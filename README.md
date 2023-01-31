# ReactRedisNetDocker
Interview excercise

Created a SPA app with .NET 6, React, Redis and Docker technologies.

Data comes from here: https://cosemgtest.blob.core.windows.net/mgtest/showcase.json

You have to build dockerFile from MindGeek folder, dockerFile from MindGeek.App folder and then go to main folder and docker compose.

docker build app command: docker build --rm -t <name>/mindgeek_app:latest .
docker build api command: docker build --rm -t <name>/mindgeek_api:latest .
docker compose command: docker compose up -d

Backend url: http://localhost:5000
Frontend url: http://localhost:3000

First thing you have to do after you build it, you have to send a POST request with the json from the url above to: http://localhost:5000/movie/multiple.
This will initialize all the data to redis DB.

Afterwards, you can go to http://localhost:3000 and see the data.
