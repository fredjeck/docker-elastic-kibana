# Local Development Elastic Docker-Compose

This repository hosts a simple setup allowing to run a local instance of Elastic, Kibana and Logstash which will scrape the log out of the container of your choice.
The repo comes with a sample dotnet webapi, feel free to scrape it and replace it by your own app.

## How does it work

This is a multi layer cake :

 - Docker uses the GELF format to forward your container logs to a logstash agent configured in the **assets/logstash/agent/logstash.conf folder**
 - The logstash agent stores temporarily the logs into a redis cache
 - A central logstash instance configured in the **assets/logstash/central/logstash.conf folder** takes care of exhausting the logs from redis and forwads the log to Elastic

 ## Running

 Run

 ```bash
 docker-compose up
 ```

 Open your browser and navigate to : http://localhost:5601

 Kibana might ask you to generate a code to associate Kibana and Elastic, just follow the instructions

 ## Misc

 Not invented here, based on mutliple articles found on the interwebs