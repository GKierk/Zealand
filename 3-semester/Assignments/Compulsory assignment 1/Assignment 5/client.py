import json
from socket import *

serverName = "localhost"
serverPort = 5000
clientSocket = socket(AF_INET, SOCK_STREAM)
clientSocket.connect((serverName, serverPort))

def json_communication():
    data = input()
    data = {"operation": data}
    clientSocket.send(json.dumps(data).encode())
    response = clientSocket.recv(1024).decode()
    response = json.loads(response)
    print(f"{response["response"]}")
    data = input()
    data = {"numbers": data}
    clientSocket.send(json.dumps(data).encode())
    response = clientSocket.recv(1024).decode()
    response = json.loads(response)
    print(f"{response["response"]}")    

def send_server_request():
    json_communication()
    clientSocket.close()

def main():
    send_server_request()

__name__ == "__main__" and main()