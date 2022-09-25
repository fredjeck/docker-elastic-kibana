# Local Development Elastic Docker-Compose

This repository hosts different kinds of setup allowing you to run an ELK stack locally for development purposes. This can be useful for testing or simply fine tuning your structured logs locally.

## How does it work

This repository comes in two flavors:

### Using Logstash and the GELF Docker logging driver

Start the docker compose file in the elastic-logstash folder `docker compose up`. This will start up multiple containers: 

 - Elastic
 - Kibana
 - A Redis Cache
 - A first logstash agent which will be sent the logs from your application's docker container and will store the logs in your the Redis cache (configured in **assets/logstash/agent/logstash.conf**)
 - A second logstash agent (logstash-central) which takes care of exhausting the logs from redis and forwads the log to Elastic (configured in **assets/logstash/central/logstash.conf**)

A sample GELF docker driver setup can be found here in the **sample-app/docker-compose-gelf.yml**

### Using Fluentbit

Using fluent bit is simpler as is just requires a fluentbit container which will be sent the logs through the fluentd docker driver.
Fluentbit is configured in **assets/fluent/fluent-bit.conf**)

A sample FLUENTD docker driver setup can be found here in the **sample-app/docker-compose-fluent.yml**

 ## Running

Start by running the stack of your choice and add the logging driver to your container.

 ```bash
 docker-compose up
 ```

 Open your browser and navigate to : http://localhost:5601

 Kibana might ask you to generate a code to associate Kibana and Elastic, just follow the instructions

 ## Misc

 Not invented here, based on mutliple articles found on the interwebs