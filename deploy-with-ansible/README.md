# Infrastrucure as Code (IaC) with [Ansible Notebook](https://docs.ansible.com/)
* Install Docker on Ubuntu 24.04
* Config SSH key-based authentication to your server


## Install Ansible Notebook
* Required [Python 3.8 or higher](https://www.python.org/downloads/)

Initial python environment setup
```
$python -m venv ./demo/venv
$source ./demo/venv/bin/activate
$export PATH=.:$(pwd)/demo/venv/bin/:$PATH
$alias pip=pip3
```

Install Ansible
```
$pip install ansible
$pip list


$ansible --version
ansible [core 2.20.4]
```

## Create and Run Ansible Notebook
* inventory.ini - list of servers to manage
* install-docker-ubuntu.yml - Ansible playbook to install Docker on Ubuntu
* uninstall-docker-ubuntu.yml - Ansible playbook to uninstall Docker on Ubuntu


Install Docker on Ubuntu 24.04
```
# Run the installation playbook
$ansible-playbook -i inventory.ini install-docker-ubuntu.yml

# Run with verbose output for troubleshooting
$ansible-playbook -i inventory.ini install-docker-ubuntu.yml -v

# Check docker installation
$ansible -i inventory.ini all -m command -a "docker --version"
$ansible -i inventory.ini all -m command -a "docker compose version"
```

Uninstall Docker on Ubuntu 24.04
```
# Run the uninstallation playbook
$ansible-playbook -i inventory.ini uninstall-docker-ubuntu.yml

# Run with verbose output for troubleshooting
$ansible-playbook -i inventory.ini uninstall-docker-ubuntu.yml -v
```

## Deploying Application with Ansible
* Try to build images and push to Container Registry (Docker Hub, AWS ECR, etc.) before running the deployment playbook
* docker-compose.yml - Docker Compose file to define the application services
* deploy-app-with-docker.yml - Ansible playbook to deploy the application using Docker Compose

Deploy the application using Ansible
```
# Run the deployment playbook
$ansible-playbook -i inventory.ini deploy-app-with-docker.yml

# Run with verbose output for troubleshooting
$ansible-playbook -i inventory.ini deploy-app-with-docker.yml -v
```

Undeploy the application using Ansible
```
# Run the undeployment playbook
$ansible-playbook -i inventory.ini undeploy-app-with-docker.yml

# Run with verbose output for troubleshooting
$ansible-playbook -i inventory.ini undeploy-app-with-docker.yml -v
```